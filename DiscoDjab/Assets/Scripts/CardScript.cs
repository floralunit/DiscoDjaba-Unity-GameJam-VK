using Assets.Scripts;
using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                var direction = this.CardDirection;
                hasBeenPlayed = true;
                this.transform.position += Vector3.down;
                Invoke("SetAvailable", 2f);
                Invoke("MoveToDiscardPile", 2f);
                StartCoroutine(FrogMovement.Instance.MoveFrog(direction));
            }
        }
    }

    void SetAvailable()
    {
        gm.avalibaleCardSlots[handIndex] = true;
    }

    void MoveToDiscardPile()
    {

        gm.discard.Add(this);
        gm.handDeck.Remove(this);
        gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        //_highlight.SetActive(true);
        transform.localScale += new Vector3(0.08f, 0.08f, 0.08f);
    }

    void OnMouseExit()
    {
        //_highlight.SetActive(false);
        transform.localScale -= new Vector3(0.08f, 0.08f, 0.08f);
    }

}
