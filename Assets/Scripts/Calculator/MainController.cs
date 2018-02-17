using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Calculator
{
    public class MainController : MonoBehaviour
    {
        public AdditionalCalculatorController additionalCalculator;
        public GameObject UITopBar, UICalculator, gameCamera;

        [HideInInspector]
        public GameObject selectedButton;
        [HideInInspector]
        public bool isLose, isWin, isPlaying;
        private int[] generatedCode, enteredCode;

        public List<GameObject> DisplayCalculatorValues { get; set; }

        private TopBarController topBarController;

        private void ResetValuesToDefault()
        {
            isLose = false;
            isWin = false;
            //TODO Generate unique symbols
            generatedCode = CalcExtenisons.GenerateCode();
            ResetDisplayValues();
            topBarController.ResetValuesToDefault();
        }


        void Start()
        {
            DisplayCalculatorValues = GameObject.FindGameObjectsWithTag("MainDisplayNumber").OrderBy(x => x.gameObject.name).ToList();
            topBarController = UITopBar.GetComponent<TopBarController>();
            ResetValuesToDefault();
        }

        public void StartGame()
        {
            UITopBar.SetActive(true);
            UICalculator.SetActive(true);

            ResetValuesToDefault();
            ResetDisplayValues();
            isPlaying = true;
        }

        public void StopGame()
        {
            UITopBar.SetActive(false);
            UICalculator.SetActive(false);
            isPlaying = false;
        }

        void Update()
        {
            if (isWin)
            {
                topBarController.level++;
                isWin = false;
                StopGame();
                gameCamera.GetComponent<Animator>().SetTrigger("win");
            }
            if (isLose)
            {
                isLose = false;
                StopGame();
                gameCamera.GetComponent<Animator>().SetTrigger("lose");
                Debug.Log("YOU LOSE");
            }
        }

        public void ChangeValue(GameObject passedButton)
        {
            var value = passedButton.name.Split('_')[1];
            if (selectedButton == null)
                return;

            var nextDisplayIndex = 0;
            for (int i = 0; i < DisplayCalculatorValues.Count; i++)
            {
                if (DisplayCalculatorValues[i].gameObject.name == selectedButton.name)
                {
                    nextDisplayIndex = i + 1;
                }
            }

            if (nextDisplayIndex > 5)
                nextDisplayIndex = 0;

            selectedButton.GetComponentInChildren<Text>().text = value;

            ResetDisplayColor();
            DisplayCalculatorValues[nextDisplayIndex].GetComponentInChildren<Image>().color = new Color(0.15f, 0.456f, 0.15f, 0.75f);
            selectedButton = DisplayCalculatorValues[nextDisplayIndex];
        }

        public void ResetDisplayColor()
        {
            var buttons = GameObject.FindGameObjectsWithTag("MainDisplayNumber");
            foreach (var button in buttons)
            {
                button.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            }
        }

        public void ResetDisplayValues()
        {

            ResetDisplayColor();
            foreach (var button in DisplayCalculatorValues)
            {
                button.GetComponentInChildren<Text>().text = "0";
            }
            DisplayCalculatorValues[0].GetComponentInChildren<Image>().color = new Color(0.15f, 0.456f, 0.15f, 0.75f);
            selectedButton = DisplayCalculatorValues[0];
            additionalCalculator.ResetToDefault();
        }

        private int[] GetEnteredCode()
        {
            var code = new int[6];
            var buttons = GameObject.FindGameObjectsWithTag("MainDisplayNumber").OrderBy(x => x.name.Split('_')[1]).ToList();
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
                if (topBarController.health <= 1)
                {
                    isLose = true;
                    return;
                }

                topBarController.ReduceHealth();
                Debug.Log("Incorrect Value");

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
