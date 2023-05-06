using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public List<CardScript> deck = new List<CardScript>();
    public List<CardScript> discard = new List<CardScript>();
    public Transform[] cardSlots;
    public bool[] avalibaleCardSlots;
    
    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            CardScript randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < avalibaleCardSlots.Length; i++)
            {
                if (avalibaleCardSlots[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;
                    
                    randCard.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    avalibaleCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void Shuffle()
    {
        if (discard.Count >= 1)
        {
            foreach (CardScript card in discard)
            {
                deck.Add(card);
            }
            discard.Clear();
        }
    }
}
