using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private void Start()
    {
        transform.position = new Vector2(4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving && transform.position.y < 8) { 
            StartCoroutine(MoveFrog(Vector3.up));
        }
        if (Input.GetKey(KeyCode.A) && !isMoving && transform.position.x > 0)
        {
            StartCoroutine(MoveFrog(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving && transform.position.y > 0)
        {
            StartCoroutine(MoveFrog(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving && transform.position.x < 8)
        {
            StartCoroutine(MoveFrog(Vector3.right));
        }
    }

    private IEnumerator MoveFrog(Vector3 direction)
    {
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
}
