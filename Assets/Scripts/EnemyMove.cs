using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform[] Waypoints;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int waypointIndex;

    void Start()
    {
        SetStartPos();
        SetRunAnim();
    }

    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
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

    void SetRunAnim()
    {
        animator = GetComponent<Animator>();
        if (animator != null )
            animator.SetBool("Running", true);
    }

    void SetStartPos()
    {
        transform.position = Waypoints[waypointIndex].transform.position;
    }
}
