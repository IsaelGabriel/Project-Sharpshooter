using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SignalHandler
{
    [SerializeField]private GameObject pauseMode,pauseMenu;
    public static bool gamePaused = false;

    void Start()
    {
        SetGamePauseMode(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            SetGamePauseMode(!gamePaused);
            GameManager.SetMouseFocusMode(!gamePaused);
            SendSignal((gamePaused)? "GamePaused" : "!GamePaused");
        }
    }

    private void SetGamePauseMode(bool m)
    {
        gamePaused = m;
        pauseMode.SetActive(m);
        pauseMenu.SetActive(m);
        Time.timeScale = (m)? 0f : 1f;
    }
}
