using Assets.Scripts.Calculator;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : CalculatorButton
{
    void Start()
    {
        Init();
        button.onClick.AddListener(ButtonPassed);
    }

    private void ButtonPassed()
    {
        mainController.ChangeValue(gameObject);
    }



}
