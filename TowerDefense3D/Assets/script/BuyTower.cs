using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] private GameObject TowerPrefab;
    public static float towerCount = 0;

    private MoneySystem moneySystem;

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
                //Debug.Log(moneySystem.money);
            }
            else
            {
                return;
            }
            towerCount++;
        }
    }    
}
