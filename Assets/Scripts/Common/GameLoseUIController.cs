using Assets.Scripts.Calculator;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoseUIController : MonoBehaviour {

    private MainController mainController;

    void Start () {
        mainController = FindObjectOfType<MainController>();
    }

    public void ContinueGame()
    {
        mainController.DisableLoseEffects();
        mainController.isWin = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
