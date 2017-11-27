using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{

    public string wordIdentifire = "";

    void Start ()
	{
	    gameObject.GetComponent<Text>().text = LocalizationManager.GetWord(wordIdentifire);
	}
	
}
