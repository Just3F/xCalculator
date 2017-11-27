using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private static LocalizationContainer loc;
    private static Languages language;

    private enum Languages
    {
        RU,
        EU
    }

    void Awake()
    {
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
            case Languages.RU:
                return wordObject.RU;
            case Languages.EU:
                return wordObject.EU;
        }

        return "";
    }
}
