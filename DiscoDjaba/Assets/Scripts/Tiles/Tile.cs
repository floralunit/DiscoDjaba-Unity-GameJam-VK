using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public Color _color;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue };

    public void Init(int num)
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];

        // Создаем экземпляр Tile с указанным цветом
        _renderer.color = randomColor;
        _color = _renderer.color;
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