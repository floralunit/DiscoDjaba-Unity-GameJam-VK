using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CardsManager
    {

        public static Card GetNewCard()
        {
            Card card = new Card();
            card.CardColor = ColorDirectionHelp.SetRandomColor();
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
        public static List<CardScript> CardsDeck = new List<CardScript>()
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
    }
}
