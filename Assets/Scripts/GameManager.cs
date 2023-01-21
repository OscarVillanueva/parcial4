using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void PlayerInteractionActions();
    public static event PlayerInteractionActions OnPlayerInteractions;

    public static GameManager sharedInstance;

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        else sharedInstance = null;
    }

    public void InitIniteractions()
    {
        OnPlayerInteractions?.Invoke();
    }
}
