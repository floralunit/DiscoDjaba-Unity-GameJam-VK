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
    [SerializeField] private GameObject _square;

    [SerializeField] private SpriteRenderer _rendererArrow;

    public Color CardColor;
    public Vector3 CardDirection;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManagerScript gm;

    public void Init(CardScript card)
    {
        _rendererSquare.color = card.CardColor;
        string direction = "";
        var angle = new Vector3(0, 0, 0);
        if (card.CardDirection == Vector3.left) angle = new Vector3(0, 0, 90);
        if (card.CardDirection == Vector3.right) angle = new Vector3(0, 0, -90);
        if (card.CardDirection == Vector3.down) angle = new Vector3(0, 0, -180);
        _rendererArrow.transform.eulerAngles = angle;
    }

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 20;
            hasBeenPlayed = true;
            gm.avalibaleCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        gm.discard.Add(this);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();
        //_rendererSquare.color = ColorDirectionHelp.SetRandomColor();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
