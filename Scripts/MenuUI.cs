using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MenuUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;

    public bool gamePaused = false;

    public void UI()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gamePaused = true;
    }
}
