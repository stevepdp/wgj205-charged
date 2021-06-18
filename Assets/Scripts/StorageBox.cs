using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{
    public int boxCharge;
    public GameObject player;
    private bool _canMove = true;
    [SerializeField]
    private float _distanceFromPlayer;
    [SerializeField]
    private float distanceThreshold = 1f;
    [SerializeField]
    private float _directionNo;
    public bool isDeadly = false;

    enum charge
    {
        neutral,  //0
        negative, //1
        positive  //2
    }

    private void Start()
    {
    }

    void Update()
    {
        if (boxCharge > 0)
        {
            CalcDistanceFromPlayer();
            CalcDirectionFacingFromPlayer(); // borrowed from: https://forum.unity.com/threads/left-right-test-function.31420/
            SeekPlayer();
            DeadlyCheck();
        }
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f) return 1f;
        else if (dir < 0f) return -1f;
        else return 0f;
    }

    void CalcDistanceFromPlayer()
    {
        _distanceFromPlayer = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);
    }

    void CalcDirectionFacingFromPlayer()
    {
        Vector3 heading = player.GetComponent<Transform>().position - transform.position;
        _directionNo = AngleDir(transform.forward, heading, transform.up);

        // this also determines in which direction force should be applied to the object. Right to left for left movement, left to right for right movement
    }

    void DeadlyCheck()
    {
        float maxSpeed = 1.0f; // units/sec
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 vel = rb.velocity;
        if (vel.magnitude < maxSpeed)
        {
            isDeadly = false;
        }
        
    }

    void SeekPlayer()
    {
        if (_canMove)
        {
            if ((_distanceFromPlayer < distanceThreshold) && player.GetComponent<Player>()._playerChargeNo != boxCharge) // only opposites attract
            {
                // player is left of me
                if (_directionNo == 1)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.33f, 0), ForceMode2D.Impulse); // FIRE LEFT
                    
                }
                // player is right of me
                else if (_directionNo == -1)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.33f, 0), ForceMode2D.Impulse); // FIRE RIGHT  
                }
            }
        }
    }
}