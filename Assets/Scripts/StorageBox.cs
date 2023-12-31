using UnityEngine;

public class StorageBox : MonoBehaviour
{
    const byte DEADLY_SPEED_THRESHOLD = 1;
    Player player;
    Rigidbody2D rb;
    Transform playerTransform;
    public bool isDeadly = false;
    [SerializeField] float distanceFromPlayer;
    [SerializeField] float distanceThreshold = 1f;
    [SerializeField] float directionNo;
    public int boxCharge;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        playerTransform = player?.GetComponent<Transform>();
    }

    void Update()
    {
        CalcDistanceFromPlayer();
        CalcDirectionFacingFromPlayer(); // borrowed from: https://forum.unity.com/threads/left-right-test-function.31420/
        SeekPlayer();
        DeadlyCheck();
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
        if (boxCharge > 0) distanceFromPlayer = Vector3.Distance(playerTransform.position, transform.position);
    }

    void CalcDirectionFacingFromPlayer()
    {
        if (boxCharge > 0)
        {
            Vector3 heading = playerTransform.position - transform.position;
            directionNo = AngleDir(transform.forward, heading, transform.up);
            // this also determines in which direction force should be applied to the object. Right to left for left movement, left to right for right movement
        }
    }

    void DeadlyCheck()
    {
        if (rb != null && boxCharge > 0)
        {
            Vector2 vel = rb.velocity;
            if (vel.magnitude < DEADLY_SPEED_THRESHOLD)
                isDeadly = false;
        }
    }

    void SeekPlayer()
    {
        if (Player.Instance != null)
        {
            if (boxCharge > 0 && (distanceFromPlayer < distanceThreshold) && Player.Instance.Charge != boxCharge) // only opposites attract
            {
                // player is left of me
                if (directionNo == 1)
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.33f, 0), ForceMode2D.Impulse); // FIRE LEFT

                // player is right of me
                else if (directionNo == -1)
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.33f, 0), ForceMode2D.Impulse); // FIRE RIGHT  
            }
        }
    }
}