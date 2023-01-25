using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestRoomController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.sharedInstance.IsFloorClear = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
