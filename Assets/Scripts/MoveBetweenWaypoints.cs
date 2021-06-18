using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenWaypoints : MonoBehaviour
{
    public Transform[] Waypoints;
    public float moveSpeed = 2f;
    public int waypointIndex = 0;

    private Animator _animator;

    void Start()
    {
        transform.position = Waypoints[waypointIndex].transform.position;
        _animator = GetComponent<Animator>();
        _animator.SetBool("Running", true);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                  Waypoints[waypointIndex].transform.position,
                                                  moveSpeed * Time.deltaTime);

        if (transform.position == Waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        if (waypointIndex == Waypoints.Length)
        {
            waypointIndex = 0;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
