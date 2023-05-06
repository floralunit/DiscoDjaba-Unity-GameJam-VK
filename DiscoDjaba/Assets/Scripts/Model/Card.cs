using Assets.Scripts.Model;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class Card
    {
        public Color[] CardColors { get; set; }
        public Vector3 CardDirection { get; set; }
        public static Card GetNewCard()
        {
            Card card = new Card();
            System.Random rnd = new System.Random();
            int numColors = rnd.Next(0, 2);
            for (int c = 0; c < numColors; c++)
            {
                card.CardColors[c] = ColorDirectionHelp.SetRandomColor();
            }
            card.CardDirection = ColorDirectionHelp.SetRandomDirection();
            return card;
        }
        public static List<Card> GetStartCards()
        {
            var cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                cards.Add(GetNewCard());
            }
            return cards;
        }

    }

}
