using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Calculator
{
    public class MainController : MonoBehaviour
    {
        [HideInInspector]
        public GameObject selectedButton;

        private bool isLose, isWin;
        private int[] generatedCode, enteredCode;


        private void ResetValuesToDefault()
        {
            isLose = false;
            isWin = false;
            generatedCode = CalcExtenisons.GenerateCode();
            ResetDisplayValues();
            Debug.Log(generatedCode);
        }

        void Start ()
        {
            ResetValuesToDefault();
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
            CalcExtenisons.LogArray(enteredCode);
        }

    }
}
