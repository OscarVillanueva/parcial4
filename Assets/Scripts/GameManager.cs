using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void PlayerInteractionActions();
    public static event PlayerInteractionActions OnPlayerInteractions;

    public delegate void FloorWasCompleted();
    public static event FloorWasCompleted OnFloorCompleted;

    public static GameManager sharedInstance;

    private bool isFloorClear;

    public bool IsFloorClear
    {
        get => isFloorClear;
        set
        {
            isFloorClear = value;
            if (isFloorClear)
            {
                OnFloorCompleted?.Invoke();
            }
        }
    }

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        else sharedInstance = null;
    }

    private void Start()
    {
        isFloorClear = false;
    }

    public void InitIniteractions()
    {
        OnPlayerInteractions?.Invoke();
    }

}
