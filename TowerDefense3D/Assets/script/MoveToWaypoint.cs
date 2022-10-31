using UnityEngine.UI;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float movementSpeed = 5f;
    int wayPointIndex = 0;

    public float startHealth = 100;
    private float health;

    public Image healthbar;

    private MoneySystem moneySystem;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
        moneySystem = GameObject.Find("EventSystem").GetComponent<MoneySystem>();
        health = startHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        startHealth -= damageAmount;

        healthbar.fillAmount = startHealth/health;
        Debug.Log(healthbar.fillAmount);

        if(startHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        moneySystem.money += 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movementSpeed * Time.deltaTime);
        transform.LookAt(wayPoints[wayPointIndex]);

        if (transform.position == wayPoints[wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
        }

        if (wayPointIndex == wayPoints.Length)
        {
            PathEnds();
        }
    }

    void PathEnds()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
