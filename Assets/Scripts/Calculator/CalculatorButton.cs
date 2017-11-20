using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Calculator
{
    public class CalculatorButton : MonoBehaviour
    {
        protected MainController mainController;
        protected Button button;
        void Start()
        {
            Init();
            if(gameObject.name == "Button_Reset")
                button.onClick.AddListener(ResetMainDisplay);

            if(gameObject.name == "Button_Deactivate")
                button.onClick.AddListener(Deactivate);
        }

        protected void Init()
        {
            mainController = FindObjectOfType<MainController>();

            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(PlaySound);
        }

        private void ResetMainDisplay()
        {
            mainController.ResetDisplayValues();
        }

        private void Deactivate()
        {
            mainController.Deactivate();
        }

        private void PlaySound()
        {
            //FindObjectOfType<AudioManager>().Play("BtnClick");
            //Debug.Log("PLAY SOUND");
        }

    }
}
