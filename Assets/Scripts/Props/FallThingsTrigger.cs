using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThingsTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: Decirle al manager que se comiencen a caer las cosas
        }
    }
}
