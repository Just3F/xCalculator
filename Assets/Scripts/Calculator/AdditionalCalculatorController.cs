using UnityEngine;
using UnityEngine.UI;

public class AdditionalCalculatorController : MonoBehaviour
{

    private int stackCount;
    public Text[] additionalTexts = new Text[3];


    public void ResetToDefault()
    {
        stackCount = 0;
        foreach (var text in additionalTexts)
        {
            text.text = "000000";
        }
    }

	void Start ()
	{
	    ResetToDefault();
	}

    public void AddCode(string code)
    {
        switch (stackCount)
        {
            case 0:
                additionalTexts[0].text = code;
                stackCount++;
                break;
            case 1:
                additionalTexts[1].text = additionalTexts[0].text;
                additionalTexts[0].text = code;
                stackCount++;
                break;
            case 2:
                additionalTexts[2].text = additionalTexts[1].text;
                additionalTexts[1].text = additionalTexts[0].text;
                additionalTexts[0].text = code;
                break;
        }
    }
	
}
