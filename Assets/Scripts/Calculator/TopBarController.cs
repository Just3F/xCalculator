using Assets.Scripts.Calculator;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

public class TopBarController : MonoBehaviour
{
    private float timer;
    private int health, level;
    public Text LevelText, HealthText, TimerText;
    private MainController mainController;

    public void ResetValuesToDefault()
    {
        timer = 65f;
        health = 9;
        level = 0;
    }

    void Start()
    {
        ResetValuesToDefault();
        mainController = FindObjectOfType<MainController>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        TimerText.text = CalcExtenisons.FloatToTime(timer, "#0:00");
        if (timer <= 0f)
            mainController.isLose = true;
    }
}
