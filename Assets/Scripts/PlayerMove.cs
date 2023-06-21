using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const byte MOVEMENT_SPEED = 2;

    Player player;
    PlayerHealth playerHealth;
    Rigidbody2D playerRb;
    float horizontalInput;

    void Awake()
    {
        player = GetComponent<Player>();
        playerHealth = GetComponent<PlayerHealth>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetFacingDirection();
        SetVelocity();
        SetRunState();
    }

    void SetFacingDirection()
    {
        if (player != null && playerHealth != null)
        {
            if (playerHealth.HP > 0 && !player.isExiting)
            {
                if (horizontalInput < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    player.directionFacing = "left";
                }

                if (horizontalInput > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    player.directionFacing = "right";
                }
            }
        }
    }

    void SetVelocity()
    {
        if (player != null && playerHealth != null)
        {
            if (playerHealth.HP > 0 && !player.isExiting)
            {
                horizontalInput = Input.GetAxisRaw("Horizontal");
                if (!player.isExiting)
                    playerRb.velocity = new Vector2(horizontalInput * MOVEMENT_SPEED, playerRb.velocity.y);
            }
        }
        
    }

    void SetRunState()
    {
        if (player != null)
        {
            if (horizontalInput != 0)
                player.isRunning = true;
            else
                player.isRunning = false;
        }
    }
}