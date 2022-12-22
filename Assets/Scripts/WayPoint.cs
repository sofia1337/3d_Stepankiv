using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currPointIndex = 0;
    [SerializeField] float speed = 1f;
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currPointIndex].transform.position) < 1f)
        {
            currPointIndex++;
            if(currPointIndex >= waypoints.Length) 
            {
                currPointIndex= 0;
            }
        }
        transform.position= Vector3.MoveTowards(transform.position, waypoints[currPointIndex].transform.position,speed*Time.deltaTime);

    }
}
