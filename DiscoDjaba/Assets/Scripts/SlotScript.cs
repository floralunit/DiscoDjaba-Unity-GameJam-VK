using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotScript : MonoBehaviour
{

    void Start()
    {

        transform.position = GridManager.Instance.transform.position + Vector3.down * 3;

        switch (this.name)
        {
            case "Slot1Player1":
                {

                    break;
                }
            case "Slot2Player1":
                {
                    transform.position = transform.position + Vector3.right * 2;
                    break;
                }
            case "Slot3Player1":
                {
                    transform.position = transform.position + Vector3.right * 2 * 2;
                    break;
                }
            case "Slot4Player1":
                {
                    transform.position = transform.position + Vector3.right * 2 * 3;
                    break;
                }
            //case "Slot5Player1":
            //    {
            //        transform.position = transform.position + Vector3.right * 2 * 4;
            //        break;
            //    }
            default: break;
        }
    }

}