using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] private GameObject TowerPrefab;
    public static float towerCount = 0;

    private MoneySystem moneySystem;
    public GameObject ShopScreen;

    private void Start()
    {
        moneySystem = GameObject.Find("EventSystem").GetComponent<MoneySystem>();
    }

    public void SpawnTower()
    {
        if(moneySystem.money >= 20)
        {
            if (towerCount <= 29)
            {
                Instantiate(TowerPrefab);
                //TowerPrefab.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition);
                moneySystem.money -= 20;
                ShopScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                return;
            }
            towerCount++;
        }
    }    
}
