using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject tower;

    public bool ShopOpen = false;

    public GameObject currentDraggingTower;

    private void Start()
    {
        //tower = GameObject.FindGameObjectWithTag("towers");
        
    }
    public void ShopScreen()
    {
        shopScreen.SetActive(true);
        Time.timeScale = 0.5f;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Its over UI elements");
            Debug.Log(tower);
            if (currentDraggingTower)
            {
                currentDraggingTower.GetComponent<Tower>().shopSreenOpen = true;
            }
            ShopOpen = true;

        }
        else
        {
            Debug.Log("Its NOT over UI elements");
        }
        
    }

    public void GoBack()
    {
        shopScreen.SetActive(false);
        Time.timeScale = 1f;
        ShopOpen = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
