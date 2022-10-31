using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting};

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;

    private MoneySystem moneySystem;

    public GameObject WinScreen;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        moneySystem = GetComponent<MoneySystem>();
    }

    private void Update()
    {
        if(state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                Debug.Log("Wave Complete");
                moneySystem.money += 10;
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0f)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    { 
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;
        if(nextWave + 1 > waves.Length - 1)
        {
            WinGame();
        }
        else
        {
            nextWave++;
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0)
        {
            if (GameObject.FindGameObjectWithTag("enemy") == null)
            {
                return false;
            }
            searchCountdown = 1f;
        }        
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            Spawnenemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate); 
        }

        state = SpawnState.Waiting;
        yield break;
    }

    public void Spawnenemy(Transform _enemy)
    {        
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
