using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentTransform;
    // Start is called before the first frame update
    void Start()
    {
        currentTransform = waypoints.GetNextWaypoint(currentTransform);
        transform.position = currentTransform.position;

        currentTransform = waypoints.GetNextWaypoint(currentTransform);
        transform.LookAt(currentTransform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTransform.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentTransform.position) < distanceThreshold)
        {
            currentTransform = waypoints.GetNextWaypoint(currentTransform);
            transform.LookAt(currentTransform);
        }
    }
}
