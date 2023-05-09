using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPlayers : MonoBehaviour
{
   
    public int quantity;
     public Sprite onClick;
    public Sprite noImage;
    public Button TagButton2;
    public Button TagButton4;
    public bool isOn4;
    public bool isOn2;
    private Color32 disabled;
    private Color32 enabled;


    // Start is called before the first frame update
    void Start()
    { 
        isOn4 = true;
        isOn2 = false;

        disabled = new Color32(255, 255, 255, 0);
        enabled = new Color32(255, 255, 255, 255);

        TagButton4.GetComponent<Image>().sprite = onClick;
        TagButton2.GetComponent<Image>().sprite = noImage;
        TagButton4.GetComponent<Image>().color = enabled;
        TagButton2.GetComponent<Image>().color = disabled;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(int players){
        quantity = players;
        if(isOn2){
            isOn2=false;
            isOn4=true;
            TagButton4.GetComponent<Image>().sprite = onClick; 
            TagButton2.GetComponent<Image>().sprite = noImage; 
            TagButton4.GetComponent<Image>().color = enabled;
            TagButton2.GetComponent<Image>().color = disabled;


        } else if(!isOn2){
            isOn2=true;
            isOn4=false;
            TagButton2.GetComponent<Image>().sprite = onClick; 
            TagButton4.GetComponent<Image>().sprite = noImage; 
            TagButton2.GetComponent<Image>().color = enabled;
            TagButton4.GetComponent<Image>().color = disabled;


        }
        Debug.Log(isOn2);
        Debug.Log(isOn4);
    }
}
