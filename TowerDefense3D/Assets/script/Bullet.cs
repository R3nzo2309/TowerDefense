using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed = 50f;

    public int damageAmount = 50;

    [SerializeField] private GameObject impactEffect;

    

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {     
        MoveToWaypoint damage = target.GetComponent<MoveToWaypoint>();

        if (damage != null)
        {            
            damage.TakeDamage(damageAmount);
            //Debug.Log(damage);
        }


        GameObject effectsIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectsIns, 2f);
        Destroy(gameObject);
    }
}
