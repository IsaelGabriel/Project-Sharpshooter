using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SignalHandler
{
    public static GameManager Instance; /// Static GameManager Instace can be referenced by any object, which makes it easier to find.
    public static float mouseSensitivity = 700f;

    void Awake()
    {
        if(Instance == null) Instance = this; /// If the game doesn't have a GameManager yet, this object will take that role.
        else if (Instance != this) Destroy(gameObject); /// If the game already has a GameManager and it isn't this object, self destruct.
        DontDestroyOnLoad(Instance); /// Makes GameManager stay on game even when scenes change.
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetMouseFocusMode(true);
    }

    /// Sets cursor configuration for the game (hide and lock in center)
    public static void SetMouseFocusMode(bool focus) 
    {
        if(Cursor.visible != focus) return;
        Cursor.lockState = (focus)? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !focus;
    }
}
