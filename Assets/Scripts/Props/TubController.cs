using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubController : MonoBehaviour
{

    [SerializeField] private BoxCollider interactionZone;

    private void OnEnable()
    {
        GameManager.OnFloorCompleted += ActiveInteraction;
    }

    private void ActiveInteraction()
    {
        interactionZone.enabled = true;
        GameManager.OnFloorCompleted -= ActiveInteraction;
    }

    private void OnDisable()
    {
        GameManager.OnFloorCompleted -= ActiveInteraction;
    }
}
