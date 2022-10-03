using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] private GameObject TowerPrefab;
    public static float towerCount = 0;
    
    public void SpawnTower()
    {
        if(MoneySystem.money >= 20)
        {
            if (towerCount <= 29)
            {
                Instantiate(TowerPrefab);
                //TowerPrefab.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition);
                MoneySystem.money -= 20;
                Debug.Log(MoneySystem.money);
            }
            else
            {
                return;
            }
            towerCount++;
        }
    }
}
