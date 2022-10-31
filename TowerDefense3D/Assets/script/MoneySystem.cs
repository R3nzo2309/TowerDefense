using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] public float money = 20;
    [SerializeField] private Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = ("Money: ") + money.ToString();
    }
}
