using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject GoUnityScript;
    public Image img;
     private Color32 colorOk;
    private Color32 colorError;
    private Color32 colorYellow;
    // Start is called before the first frame update
    void Start()
    {
        colorOk = new Color32(0, 200, 0, 255); // зеленый
        colorError = new Color32(200, 0, 0, 255); // красный
        colorYellow = new Color32(200, 200, 0, 255); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShareButtonClick(){
        GoUnityScript.GetComponent<UnityScript>().RequestJs();
    }

    public void ResponseFromJsOk ()
    {
        img.color = colorOk;
    }

    public void ResponseFromJsError()
    {
        img.color = colorError;
    }
}
