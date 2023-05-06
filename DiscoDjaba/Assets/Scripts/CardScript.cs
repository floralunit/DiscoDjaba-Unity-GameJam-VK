using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public string direction;
    public string color;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManagerScript gm;


    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 20;
            hasBeenPlayed = true;
            gm.avalibaleCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        gm.discard.Add(this);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
