using System;
using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Calculator
{
    public class MainController : MonoBehaviour
    {
        public AdditionalCalculatorController additionalCalculator;

        [HideInInspector]
        public GameObject selectedButton;
        [HideInInspector]
        public bool isLose, isWin;
        private int[] generatedCode, enteredCode;


        private void ResetValuesToDefault()
        {
            isLose = false;
            isWin = false;
            //TODO Generate unique symbols
            generatedCode = CalcExtenisons.GenerateCode();
            ResetDisplayValues();
        }

        void Start ()
        {
            ResetValuesToDefault();

        }

        void Update()
        {
            if (isWin)
            {
                isWin = false;
                ResetDisplayValues();
            }
        }

        public void ChangeValue(GameObject passedButton)
        {
            var value = passedButton.name.Split('_')[1];
            if (selectedButton == null)
                return;
            selectedButton.GetComponentInChildren<Text>().text = value;
        }

        public void ResetDisplayValues()
        {
            var buttons = GameObject.FindGameObjectsWithTag("MainDisplayNumber");
            foreach (var button in buttons)
            {
                button.GetComponentInChildren<Text>().text = "0";
            }
            additionalCalculator.ResetToDefault();
        }

        private int[] GetEnteredCode()
        {
            var code = new int[6];
            var buttons = GameObject.FindGameObjectsWithTag("MainDisplayNumber").OrderBy(x=>x.name.Split('_')[1]).ToList();
            for (int i = 0; i < buttons.Count; i++)
            {
                code[i] = Convert.ToInt32(buttons[i].GetComponentInChildren<Text>().text);
            }

            return code;
        }

        public void Deactivate()
        {
            enteredCode = GetEnteredCode();
            CalcExtenisons.LogArray(generatedCode);
            CalcExtenisons.LogArray(enteredCode);

            if (generatedCode.SequenceEqual(enteredCode))
            {
                isWin = true;
                Debug.Log("WIN");
            }
            else
            {
                string codeForAdditionalPanel = "";
                for (int i = 0; i < generatedCode.Length; i++)
                {
                    if (generatedCode[i] == enteredCode[i])
                        codeForAdditionalPanel += "<color=#008000ff>" + enteredCode[i] + "</color>";
                    else if (CalcExtenisons.IsEqualForOneLevel(enteredCode[i], generatedCode[i]))
                        codeForAdditionalPanel += "<color=#ffa500ff>" + enteredCode[i] + "</color>";
                    else
                        codeForAdditionalPanel += "<color=#ff0000ff>" + enteredCode[i] + "</color>";
                }
                additionalCalculator.AddCode(codeForAdditionalPanel);
            }
        }

    }
}
