using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float movementSpeed = 5f;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        var rend = GetComponent<Renderer>();

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movementSpeed * Time.deltaTime);
        transform.LookAt(wayPoints[wayPointIndex]);

        if (transform.position == wayPoints[wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
        }

        if (wayPointIndex == wayPoints.Length)
        {
            Destroy(gameObject);
        }
    }
}
