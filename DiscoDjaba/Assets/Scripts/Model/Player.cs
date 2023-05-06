using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } 
        public Vector2 WinLocation { get; set; }

        public static List<Player> FillPlayers(int numPlayers)
        {
            var players = new List<Player>();

            for (int i = 0; i < numPlayers; i++)
            {
                var player = new Player();
                player.Name = $"Игрок { i + 1}";
                player.Cards = Card.GetStartCards();
                if (numPlayers != 2 || i == 0)
                {
                    player.WinLocation = ColorDirectionHelp.playerLocations[i];
                }
                else if (i == 1)
                {
                    player.WinLocation = ColorDirectionHelp.playerLocations[i + 1];
                }
                players.Add(player);
            }

            return players;
        }

    };
}
