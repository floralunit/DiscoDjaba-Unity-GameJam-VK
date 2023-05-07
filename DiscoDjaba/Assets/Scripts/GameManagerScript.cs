using Assets.Scripts;
using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public List<CardScript> deck;
    public List<CardScript> handDeck;
    public List<CardScript> discard = new List<CardScript>();
    public Transform[] cardSlots;
    public bool[] avalibaleCardSlots;
    public static GameManagerScript Instance;

    public List<Player> Players { get; set; }
    public int RoundNum;
    [SerializeField] Text RoundText;
    public Player CurrentPlayer;
    [SerializeField] Text PlayerText;

    [SerializeField] private CardScript _cradPref;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Players = Player.FillPlayers(2);
        CurrentPlayer = Players[0];
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
                    handDeck.Add(randCard);
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

    public void DiscardCard()
    {
        CardScript randCard = handDeck[Random.Range(0, handDeck.Count)];
        if (randCard.hasBeenPlayed == false)
        {
            ;
            randCard.hasBeenPlayed = true;
            this.avalibaleCardSlots[randCard.handIndex] = true;
            this.discard.Add(randCard);
            this.handDeck.Remove(randCard);
            randCard.gameObject.SetActive(false);
            this.RoundNum++;
            if (CurrentPlayer == Players[0]) CurrentPlayer = Players[1];
            if (CurrentPlayer == Players[1]) CurrentPlayer = Players[0];
           // ChangeSlots();
        }
    }

    void MoveToDiscardPile(CardScript card)
    {

        this.discard.Add(card);
        this.handDeck.Remove(card);
        card.gameObject.SetActive(false);
    }

    //public void ChangeSlots()
    //{
    //    //var s1p1 = GameObject.Find("Slot1Player1");
    //    //var s2p1 = GameObject.Find("Slot2Player1");
    //    //var s3p1 = GameObject.Find("Slot3Player1");
    //    //var s4p1 = GameObject.Find("Slot4Player1");

    //    //var s1p2 = GameObject.Find("Slot1Player2");
    //    //var s2p2 = GameObject.Find("Slot2Player2");
    //    //var s3p2 = GameObject.Find("Slot3Player2");
    //    //var s4p2 = GameObject.Find("Slot4Player2");

    //    //if (CurrentPlayer == Players[0])
    //    //{
    //    //    s1p1.SetActive(true);
    //    //    s2p1.SetActive(true);
    //    //    s3p1.SetActive(true);
    //    //    s4p1.SetActive(true);

    //    //    s1p2.SetActive(false);
    //    //    s2p2.SetActive(false);
    //    //    s3p2.SetActive(false);
    //    //    s4p2.SetActive(false);
    //    //}

    //    //if (CurrentPlayer == Players[1])
    //    //{
    //    //    s1p1.SetActive(false);
    //    //    s2p1.SetActive(false);
    //    //    s3p1.SetActive(false);
    //    //    s4p1.SetActive(false);

    //    //    s1p2.SetActive(true);
    //    //    s2p2.SetActive(true);
    //    //    s3p2.SetActive(true);
    //    //    s4p2.SetActive(true);
    //    //}

    //    for (int i = 0; i < this.cardSlots.Count(); i++)
    //    {
    //        switch (i)
    //        {
    //            case 0 or 1 or 2 or 3:
    //                {
    //                    if (CurrentPlayer == Players[0])
    //                    {
    //                        card.gameObject.SetActive(true);
    //                    }
    //                    if (CurrentPlayer == Players[1])
    //                    {
    //                        card.gameObject.SetActive(false);
    //                    }
    //                    break;
    //                }
    //            case 4 or 5 or 6 or 7:
    //                {
    //                    if (CurrentPlayer == Players[0])
    //                    {
    //                        card.gameObject.SetActive(false);
    //                    }
    //                    if (CurrentPlayer == Players[1])
    //                    {
    //                        card.gameObject.SetActive(true);
    //                    }
    //                    break;
    //                }
    //            default: break;
    //        }
    //    }
    //}

    void CheckIfEnd()
    {
        //if (ColorDirectionHelp.playerLocations.Contains(FrogMovement.Instance.transform.position))
        //{
            if (FrogMovement.Instance.transform.position == Players[0].WinLocation)
            {
                 Debug.Log("Победил игрок 1");
            }
            else if (FrogMovement.Instance.transform.position == Players[1].WinLocation)
            {
                 Debug.Log("Победил игрок 2");
            }
        //}
    }

    public void Update()
    {
        if (avalibaleCardSlots.Any())
        {
            DrawCard();
        }

        RoundText.text = $"Раунд {RoundNum}";
        PlayerText.text = $"Ход игрока {CurrentPlayer.Name}";
    }
}
