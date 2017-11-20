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
    }
}
