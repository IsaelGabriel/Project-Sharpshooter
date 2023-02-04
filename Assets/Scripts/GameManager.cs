using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SignalHandler
{
    public static GameManager Instance;
    

    void Awake()
    {
        if(Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetMouseFocusMode(true);
    }

    public static void SetMouseFocusMode(bool focus)
    {
        if(Cursor.visible != focus) return;
        Cursor.lockState = (focus)? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !focus;
    }
}
