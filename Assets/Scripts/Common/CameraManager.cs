using Assets.Scripts.Calculator;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private MainController mainController;

    void Start()
    {
        mainController = FindObjectOfType<MainController>();
    }

    public void StartGame()
    {
        mainController.StartGame();
    }
}
