using Assets.Scripts;
using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public List<CardScript> deck;
    public List<CardScript> discard = new List<CardScript>();
    public Transform[] cardSlots;
    public bool[] avalibaleCardSlots;

    [SerializeField] private CardScript _cradPref;

    private void Start()
    {
        List<CardScript> deck_old = new List<CardScript>()
        {
            new CardScript() { CardColor = ColorDirectionHelp.colors[0], CardDirection = Vector3.up},
            new CardScript() { CardColor = ColorDirectionHelp.colors[0], CardDirection = Vector3.down},
            new CardScript() { CardColor = ColorDirectionHelp.colors[0], CardDirection = Vector3.left},
            new CardScript() { CardColor = ColorDirectionHelp.colors[0], CardDirection = Vector3.right},
            new CardScript() { CardColor = ColorDirectionHelp.colors[1], CardDirection = Vector3.up},
            new CardScript() { CardColor = ColorDirectionHelp.colors[1], CardDirection = Vector3.down},
            new CardScript() { CardColor = ColorDirectionHelp.colors[1], CardDirection = Vector3.left},
            new CardScript() { CardColor = ColorDirectionHelp.colors[1], CardDirection = Vector3.right},
            new CardScript() { CardColor = ColorDirectionHelp.colors[2], CardDirection = Vector3.up},
            new CardScript() { CardColor = ColorDirectionHelp.colors[2], CardDirection = Vector3.down},
            new CardScript() { CardColor = ColorDirectionHelp.colors[2], CardDirection = Vector3.left},
            new CardScript() { CardColor = ColorDirectionHelp.colors[2], CardDirection = Vector3.right},
            new CardScript() { CardColor = ColorDirectionHelp.colors[3], CardDirection = Vector3.up},
            new CardScript() { CardColor = ColorDirectionHelp.colors[3], CardDirection = Vector3.down},
            new CardScript() { CardColor = ColorDirectionHelp.colors[3], CardDirection = Vector3.left},
            new CardScript() { CardColor = ColorDirectionHelp.colors[3], CardDirection = Vector3.right},
        };
        foreach (var card in deck_old)
        {
            var spawnedTile = Instantiate(_cradPref, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            spawnedTile.Init(card);
            deck.Add(spawnedTile);
        }
    }

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
