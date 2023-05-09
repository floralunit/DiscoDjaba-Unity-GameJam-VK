using Assets.Scripts;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    private bool isMoving;
    public static FrogMovement Instance;

    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        transform.position = new Vector2(GridManager.Instance.transform.position.x + GridManager.Instance._width / 2, GridManager.Instance.transform.position.y + GridManager.Instance._height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving )
        {
            StartCoroutine(MoveFrog(Vector3.up));
        }
        if (Input.GetKey(KeyCode.A) && !isMoving )
        {
            StartCoroutine(MoveFrog(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving )
        {
            StartCoroutine(MoveFrog(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving )
        {
            StartCoroutine(MoveFrog(Vector3.right));
        }


        if (transform.position == GridManager.Instance.WinLocation)
        {
            GameManagerScript.Instance.GameOver(true, "");
        }
    }

    public IEnumerator MoveFrog(Vector3 direction)
    {
        Debug.Log("MoveFrog");
        isMoving= true;

        float elapseTime = 0;
        origPos = transform.position; 
        targetPos = origPos + direction;

        while(elapseTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapseTime / timeToMove));
            elapseTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        var tile = GridManager.Instance.GetTileAtPosition(targetPos);
        Debug.Log($"Легущка в координате {targetPos.x} {targetPos.y} на цвете {tile._color}");
        isMoving = false;
    }

    public bool CheckIfCanUseCard (CardScript card)
    {
        //Debug.Log("проверяем");
        var wantLocation = transform.position + card.CardDirection;
        var tile = GridManager.Instance.GetTileAtPosition(wantLocation);

        if (card.CardColor == tile._color) return true;
        return false;
    }

}
