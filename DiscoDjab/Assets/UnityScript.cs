using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class UnityScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void UnityPluginRequestJs();  
    public GameObject goControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestJs(){
        UnityPluginRequestJs();
    }

    public void ResponseOk()
    {
        goControl.GetComponent<Control>().ResponseFromJsOk();
    }
    public void ResponseError()
    {
        goControl.GetComponent<Control>().ResponseFromJsError();
    }
}
