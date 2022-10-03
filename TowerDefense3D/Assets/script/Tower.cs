using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 10f;

    [SerializeField] private string enemyTag = "enemy";

    [SerializeField] private Transform rotation;
    [SerializeField] private float fireRate = 1f;
    private float fireCountdown = 0f;

    private float mZCoord;
    [SerializeField] private GameObject rangeObject;

    private GameObject lastHitObject;
    private bool freeSpace = true;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public Transform firepoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 3;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            lastHitObject = hit.collider.gameObject;  
        }
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.seek(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();

        if (target == null)
        {
            return;
        }
        else
        {
            fireCountdown -= Time.deltaTime;
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotationMovement = lookRotation.eulerAngles;
        rotation.rotation = Quaternion.Euler(0f, rotationMovement.y, 0f);

        
    }

    public void SellTower()
    {
        Destroy(gameObject);
        MoneySystem.money += 10;
        BuyTower.towerCount -= 1;
    }

    //dragging the tower
    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rangeObject.SetActive(true);
    }

    private void OnMouseUp()
    {
        rangeObject.SetActive(false);
    }
    
    void OnMouseDrag()

    {
        if (lastHitObject)
        {
            transform.position = lastHitObject.transform.position + new Vector3(0, 1f, 0);
        }
        
        target = null;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SellTower();
        }
    }

    private Vector3 GetMouseAsWorldPoint()

    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
