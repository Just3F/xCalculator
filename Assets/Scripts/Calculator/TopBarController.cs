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

    public void ResetValuesToDefault()
    {
        timer = 30f;
        health = 6;
        levelText.text = level.ToString();
        healthText.text = health.ToString();
    }

    public void ReduceHealth()
    {
        health--;
        healthText.text = health.ToString();
    }

    void Start()
    {
        //ResetValuesToDefault();
        mainController = FindObjectOfType<MainController>();
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
