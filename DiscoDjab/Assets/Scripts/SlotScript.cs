using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotScript : MonoBehaviour
{

    void Start()
    {

        transform.position = GridManager.Instance.transform.position + Vector3.down * 2 + new Vector3 (0.3f, 0 ,0);

        switch (this.name)
        {
            case "Slot1Player1":
                {

                    break;
                }
            case "Slot2Player1":
                {
                    transform.position = transform.position + new Vector3(0.3f, 0, 0) + new Vector3(1.5f, 0, 0);
                    break;
                }
            case "Slot3Player1":
                {
                   transform.position = transform.position + new Vector3(0.6f, 0, 0) + new Vector3(3, 0, 0);
                    break;
                }
            case "Slot4Player1":
                {
                    transform.position = transform.position + new Vector3(0.9f, 0, 0) + new Vector3(4.5f, 0, 0);
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