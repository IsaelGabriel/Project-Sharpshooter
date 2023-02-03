using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")) GameManager.SetMouseFocusMode(false);
        if(Input.GetButtonDown("Submit")) GameManager.SetMouseFocusMode(true);
    }

    public static void SetMouseFocusMode(bool focus)
    {
        if(Cursor.visible != focus) return;
        Cursor.lockState = (focus)? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !focus;
        Debug.Log((focus)? "Focus" : "Unfocus");
    }
}
