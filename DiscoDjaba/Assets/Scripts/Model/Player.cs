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
        public List<CardScript> Cards { get; set; } 
        public Vector3 WinLocation { get; set; }

        public static List<Player> FillPlayers(int numPlayers)
        {
            var players = new List<Player>();

            for (int i = 0; i < numPlayers; i++)
            {
                var player = new Player();
                player.Name = $"Игрок { i + 1}";
                //player.Cards = CardsManager.GetStartCards();
                if (numPlayers != 2 || i == 0)
                {
                    player.WinLocation = new Vector3( 0, GridManager.Instance._height - 1, 0 );
                }
                else if (i == 1)
                {
                    player.WinLocation = new Vector3(GridManager.Instance._width - 1, GridManager.Instance._height - 1, 0);
                }
                players.Add(player);
            }

            return players;
        }

    };
}
