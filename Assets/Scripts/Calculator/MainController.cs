using System;
using System.Collections;
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
        public GameObject UITopBar, UICalculator, UIGameLose, gameCamera;

        [HideInInspector]
        public GameObject selectedButton;
        [HideInInspector]
        public bool isLose, isWin, isPlaying;
        private int[] generatedCode, enteredCode;

        public ParticleSystem Explosion, Smoke, SmokeBuild;
        public GameObject Build_01, DestroyBuild;
        public Image BatteryLabel;

        public Text GameLoseText;

        public List<Sprite> BatteryImages;


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
            SetBatteryLabel();
        }

        private void SetBatteryLabel()
        {
            var batteryLvl = PlayerPrefs.GetInt("battery", 5);
            BatteryLabel.sprite = BatteryImages[batteryLvl];
        }

        void Start()
        {
            DisplayCalculatorValues = GameObject.FindGameObjectsWithTag("MainDisplayNumber").OrderBy(x => x.gameObject.name).ToList();
            topBarController = UITopBar.GetComponent<TopBarController>();
            //ResetValuesToDefault();
        }

        public void StartGame()
        {
            if (PlayerPrefs.GetInt("battery", 5) < 0)
            {
                Debug.Log("You need to charge your battery.");
                return;
            }
            UITopBar.SetActive(true);
            UICalculator.SetActive(true);

            ResetValuesToDefault();
            ResetDisplayValues();
            isPlaying = true;
            gameCamera.GetComponent<Animator>().SetTrigger("GoToBuild_01");

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
                gameCamera.GetComponent<Animator>().SetTrigger("GoToNextLevel");
            }
            if (isLose)
            {
                PlayerPrefs.SetInt("battery", PlayerPrefs.GetInt("battery", 5) - 1);
                isLose = false;
                StopGame();
                gameCamera.GetComponent<Animator>().SetTrigger("lose");
                Explosion.Play();
                SmokeBuild.Play();
                StartCoroutine("EnableCameraSmoke");
                Build_01.SetActive(false);
                DestroyBuild.SetActive(true);
                Debug.Log("YOU LOSE");
            }
        }

        public void DisableLoseEffects()
        {
            UIGameLose.SetActive(false);
            Smoke.Stop();
            Smoke.gameObject.SetActive(false);
            Explosion.Stop();
            SmokeBuild.Stop();
        }

        IEnumerator EnableCameraSmoke()
        {
            yield return new WaitForSeconds(3.0f);
            UIGameLose.SetActive(true);
            var text = GameLoseText.text.Replace("[lvl]", topBarController.level.ToString());
            GameLoseText.text = text;
            Smoke.Play();
            yield return null;
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
            DisplayCalculatorValues = GameObject.FindGameObjectsWithTag("MainDisplayNumber").OrderBy(x => x.gameObject.name).ToList();

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
