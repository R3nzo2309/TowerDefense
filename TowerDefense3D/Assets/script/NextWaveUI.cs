using UnityEngine.UI;
using UnityEngine;

public class NextWaveUI : MonoBehaviour
{
    [SerializeField] private Text NextWave;

    private SpawnEnemy spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        NextWave.text = ("Next wave in: ") + SpawnEnemy.SpawnState.Waiting;
    }
}
