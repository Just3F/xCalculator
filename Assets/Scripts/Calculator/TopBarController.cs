using Assets.Scripts.Calculator;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

public class TopBarController : MonoBehaviour
{
    private float timer;
    public int health, level = 1;
    public Text levelText, timerText, healthText;
    private MainController mainController;

    void Awake()
    {
        //ResetValuesToDefault();
        mainController = FindObjectOfType<MainController>();
    }

    public void ResetValuesToDefault()
    {
        switch (mainController.CurrentDifficult)
        {
            case 1:
                timer = 300f;
                health = 7;
                break;
            case 2:
                timer = 180f;
                health = 5;
                break;
            case 3:
                timer = 120f;
                health = 4;
                break;
        }

        levelText.text = level.ToString();
        healthText.text = health.ToString();
    }

    public void ReduceHealth()
    {
        health--;
        healthText.text = health.ToString();
    }


    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = CalcExtenisons.FloatToTime(timer, "#0:00");
        if (timer <= 0f && mainController.isPlaying)
        {
            mainController.isLose = true;
        }
    }
}
