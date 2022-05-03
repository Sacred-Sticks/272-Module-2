using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused: Time Scale at " + Time.timeScale);
        pauseMenu.SetActive(true);
    }
}
