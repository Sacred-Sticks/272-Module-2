using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public void ResumeGame()
    {
        Debug.Log("Resure");
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
