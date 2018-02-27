using UnityEngine;
using UnityEngine.UI;

public class DetailInformation : MonoBehaviour {

    private Text fpsText;
    public float deltaTime;

    void Start ()
    {
        fpsText = gameObject.GetComponent<Text>();
    }
	
	void Update () {
	    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	    float fps = 1.0f / deltaTime;
	    fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
