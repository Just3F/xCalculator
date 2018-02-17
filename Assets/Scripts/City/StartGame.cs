using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Calculator;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private MainController mainController;
    private GameObject camera;

    void Start()
    {
        mainController = FindObjectOfType<MainController>();
        camera = GameObject.Find("Camera");
    }

    void OnMouseDown()
    {
        camera.GetComponent<Animator>().SetTrigger("go_to_build_01_01");
        //mainController.StartGame();
    }
}
