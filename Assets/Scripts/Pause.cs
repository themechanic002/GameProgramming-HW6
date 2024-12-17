using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeActive();
            }
            else
            {
                PauseActive();
            }
        }
    }

    public void ResumeActive()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Debug.Log("Resume");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseActive()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Debug.Log("Pause");
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ReplayGame()
    {
        Debug.Log("Replay");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void ToMain()
    {
        Debug.Log("아직 미구현입니다...");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
    }
}
