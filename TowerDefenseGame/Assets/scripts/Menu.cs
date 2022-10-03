using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject shopScreen;
    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    public void ReturnShop()
    {
        shopScreen.SetActive(false);
    }

    public void Shop()
    {
        shopScreen.SetActive(true);
    }
}
