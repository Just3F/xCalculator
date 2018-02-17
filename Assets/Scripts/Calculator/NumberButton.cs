using Assets.Scripts.Calculator;

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
