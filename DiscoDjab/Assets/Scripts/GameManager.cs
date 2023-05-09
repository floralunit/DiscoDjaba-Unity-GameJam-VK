using Assets.Scripts;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> Players { get; set; }
    public CurrentMove CurrentMove { get; set; }
    public int PlayersNum { get; set; } = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsFirstSibling();
        Players = Player.FillPlayers(PlayersNum);
        CurrentMove = new CurrentMove() { MoveNum = 1, CurrentPlayer = Players[0] };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
