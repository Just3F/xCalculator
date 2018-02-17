using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Calculator;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

public class DisplayButton : MonoBehaviour
{
    private MainController mainController;

    void Start()
    {
        mainController = FindObjectOfType<MainController>();

        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        mainController.selectedButton = gameObject;
        Debug.Log(gameObject.GetComponentInChildren<Image>().color);
        mainController.ResetDisplayColor();
        gameObject.GetComponentInChildren<Image>().color = new Color(0.15f, 0.456f, 0.15f, 0.75f);
    }
}
