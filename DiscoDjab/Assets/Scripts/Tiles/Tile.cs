using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public Color _color;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] public GameObject _exit;
    [SerializeField] public List<GameObject> sprites;
    
    public void Init(bool isGenerateGrid)
    {
        _renderer.color = _color;
        //_renderer.sprite = sprites[rand];

        if (isGenerateGrid)
        {
            int randomChild = Random.Range(2, sprites.Count + 1);

            gameObject.transform.GetChild(randomChild).gameObject.SetActive(true);
        }
        
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}