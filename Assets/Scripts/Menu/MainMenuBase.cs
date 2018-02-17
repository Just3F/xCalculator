using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBase : MonoBehaviour
{
    private int Music, Sounds, Vibration;
    private Enums.Languages Language;
    private Dropdown LanguageDropdown;
    private Toggle MusicToggle, SoundsToggle, VibrationToggle;
    void Start()
    {
        Language = (Enums.Languages)Enum.Parse(typeof(Enums.Languages), PlayerPrefs.GetString("Language", "EU"));
        Music = PlayerPrefs.GetInt("Music", 1);
        Sounds = PlayerPrefs.GetInt("Sounds", 1);
        Vibration = PlayerPrefs.GetInt("Vibration", 1);

        LanguageDropdown = GameObject.Find("LanguageDropdown").GetComponent<Dropdown>();
        MusicToggle = GameObject.Find("MusicToggle").GetComponent<Toggle>();
        SoundsToggle = GameObject.Find("SoundsToggle").GetComponent<Toggle>();
        VibrationToggle = GameObject.Find("VibrationToggle").GetComponent<Toggle>();

        LanguageDropdown.value = (int)Language;
        MusicToggle.isOn = Music == 1;
        SoundsToggle.isOn = Sounds == 1;
        VibrationToggle.isOn = Vibration == 1;
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

    public void ChangeMusic(bool value)
    {
        PlayerPrefs.SetInt("Music", value ? 1 : 0);
    }

    public void ChangeSounds(bool value)
    {
        PlayerPrefs.SetInt("Sounds", value ? 1 : 0);
    }

    public void ChangeVibration(bool value)
    {
        PlayerPrefs.SetInt("Vibration", value ? 1 : 0);
    }

    public void ChangedLanguage(int index)
    {
        var language = ((Enums.Languages)index).ToString();
        PlayerPrefs.SetString("Language", language);
        Debug.Log("Language was changed on " + language);

        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    }
}
