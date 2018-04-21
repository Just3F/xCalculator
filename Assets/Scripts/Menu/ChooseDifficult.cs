using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Calculator;
using UnityEngine;

public class ChooseDifficult : MonoBehaviour
{
    protected MainController mainController;
    public List<GameObject> IsActiveButtons;
    void Awake()
    {
        mainController = FindObjectOfType<MainController>();
    }

    public void ChangeDifficult(int difficult)
    {
        IsActiveButtons.ForEach(x=>x.SetActive(false));
        IsActiveButtons[difficult - 1].SetActive(true); 
        mainController.ChangeDifficult(difficult);
    }
}
