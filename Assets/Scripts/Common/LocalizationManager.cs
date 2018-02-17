using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Enums
{
    public enum Languages
    {
        EU,
        RU
    }

}
public class LocalizationManager : MonoBehaviour
{
    private static LocalizationContainer loc;
    private static Enums.Languages language;



    void Awake()
    {
        language = (Enums.Languages)Enum.Parse(typeof(Enums.Languages), PlayerPrefs.GetString("Language", "EU"));
        loc = LocalizationContainer.Load();
    }

    public static string GetWord(string wordIdentifire)
    {
        var wordObject = loc.locList.FirstOrDefault(x => x.wordIdentifire == wordIdentifire);
        if (wordObject == null)
        {
            Debug.LogError("Language error!");
            return "";
        }

        switch (language)
        {
            case Enums.Languages.EU:
                return wordObject.EU;
            case Enums.Languages.RU:
                return wordObject.RU;
        }

        return "";
    }
}
