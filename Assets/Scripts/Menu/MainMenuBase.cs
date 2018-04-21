using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBase : MonoBehaviour
{
    private int Music, Sounds, Vibration;
    private Enums.Languages Language;
    private GameObject MusicOption, SoundsOption, VibrationOption, LanguageOption;
    public Sprite IsOn, IsOff;
    public List<Sprite> Flags;

    void Start()
    {
        Language = (Enums.Languages)Enum.Parse(typeof(Enums.Languages), PlayerPrefs.GetString("Language", "EU"));
        Music = PlayerPrefs.GetInt("Music", 1);
        Sounds = PlayerPrefs.GetInt("Sounds", 1);
        Vibration = PlayerPrefs.GetInt("Vibration", 1);

        SoundsOption = GameObject.Find("SoundsOption").gameObject;
        MusicOption = GameObject.Find("MusicOption").gameObject;
        VibrationOption = GameObject.Find("VibrationOption").gameObject;
        LanguageOption = GameObject.Find("LanguageOption").gameObject;

        SoundsOption.GetComponent<Image>().sprite = Sounds == 1 ? IsOn : IsOff;
        MusicOption.GetComponent<Image>().sprite = Music == 1 ? IsOn : IsOff;
        VibrationOption.GetComponent<Image>().sprite = Vibration == 1 ? IsOn : IsOff;

        LanguageOption.GetComponent<Image>().sprite = Flags[(int) Language];
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

    public void ChangeMusic()
    {
        var currentValue = PlayerPrefs.GetInt("Music");
        MusicOption.GetComponent<Image>().sprite = currentValue == 0 ? IsOn : IsOff;
        PlayerPrefs.SetInt("Music", currentValue == 0 ? 1 : 0);
    }

    public void ChangeSounds()
    {
        var currentValue = PlayerPrefs.GetInt("Sounds");
        SoundsOption.GetComponent<Image>().sprite = currentValue == 0 ? IsOn : IsOff;
        PlayerPrefs.SetInt("Sounds", currentValue == 0 ? 1 : 0);
    }

    public void ChangeVibration()
    {
        var currentValue = PlayerPrefs.GetInt("Vibration");
        VibrationOption.GetComponent<Image>().sprite = currentValue == 0 ? IsOn : IsOff;
        PlayerPrefs.SetInt("Vibration", currentValue == 0 ? 1 : 0);
    }
    public void ChangedLanguage(bool isNext)
    {
        Language = (Enums.Languages)Enum.Parse(typeof(Enums.Languages), PlayerPrefs.GetString("Language", "EU"));
        var newLang = Language.Next();
        if (!isNext)
        {

        }
        LanguageOption.GetComponent<Image>().sprite = Flags[(int)newLang];
        PlayerPrefs.SetString("Language", newLang.ToString());
    }
}

public static class Extensions
{
    public static T Next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;
        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }
}