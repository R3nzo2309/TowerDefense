using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemy);
        }
    }
}
