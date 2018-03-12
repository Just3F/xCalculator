using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{

    public string wordIdentifire = "";

    void Awake()
    {
        var text = LocalizationManager.GetWord(wordIdentifire);
        text = Regex.Replace(text, @"\s+", " ");

        text = text.Replace("[br]", "\n");

        gameObject.GetComponent<Text>().text = text;
    }

}
