using Assets.Scripts;
using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    [SerializeField] public Color _color;
    [SerializeField] private SpriteRenderer _rendererSquare;
    [SerializeField] private SpriteRenderer _rendererArrow;

    public Color CardColor;
    public Vector3 CardDirection;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManagerScript gm;

    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();

    }

    public void Init(CardScript card)
    {
        _rendererSquare.color = card.CardColor;
        var angle = new Vector3(0, 0, 0);
        if (card.CardDirection == Vector3.left) angle = new Vector3(0, 0, 90);
        if (card.CardDirection == Vector3.right) angle = new Vector3(0, 0, -90);
        if (card.CardDirection == Vector3.down) angle = new Vector3(0, 0, -180);
        _rendererArrow.transform.eulerAngles = angle;

        CardColor= card.CardColor;
        CardDirection = card.CardDirection;
    }

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            if (FrogMovement.Instance.CheckIfCanUseCard(this))
            {
                transform.position += Vector3.up;
                hasBeenPlayed = true;
                gm.avalibaleCardSlots[handIndex] = true;
                Invoke("MoveToDiscardPile", 2f);
                StartCoroutine(FrogMovement.Instance.MoveFrog(this.CardDirection));
                gm.RoundNum++;
                if (gm.CurrentPlayer == gm.Players[0]) gm.CurrentPlayer = gm.Players[1];
                if (gm.CurrentPlayer == gm.Players[1]) gm.CurrentPlayer = gm.Players[0];
                //gm.ChangeSlots();
            }
        }
    }
    void MoveToDiscardPile()
    {

        gm.discard.Add(this);
        gm.handDeck.Remove(this);
        gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        transform.localScale += new Vector3(0, 0, 0);
        transform.position += Vector3.up;
    }

    void OnMouseExit()
    {
        transform.position -= Vector3.up;
    }

}
