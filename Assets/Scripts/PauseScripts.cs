using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScripts : MonoBehaviour
{
    public GameObject GameMenu;

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameMenu.SetActive(false);
    }

    public void LeaveBody()
    {
        SceneManager.LoadScene(0);
    }
}
