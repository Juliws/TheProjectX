using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    Transform[] waypoints;
    [SerializeField]
    Transform waypointSource;
    Transform currentWaypoint;
    int currentInx;
    [SerializeField]
    float speed;
    [SerializeField]
    float moveTime;
    float timer;
    Vector3 currentVelocity;
    void Start()
    {
        currentInx = 0;
        waypoints = waypointSource.GetComponentsInChildren<Transform>();
        currentWaypoint = waypoints[currentInx];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= moveTime)
        {

            GetNextWaypoint();
            timer = 0;
        }
        Move();

    }
    void Move()
    {
        
        var target = currentWaypoint.position;
        //Debug.Log(currentWaypoint);
        target.y = transform.position.y;
        transform.LookAt(target);
        this.transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, speed);
    }
    void GetNextWaypoint()
    {
        if(currentInx + 1 < waypoints.Length)
        {
            currentInx += 1;
        }
        else
        {
            currentInx = 0;
        }
        //Debug.Log(currentInx);
        currentWaypoint = waypoints[currentInx];

    }
}
