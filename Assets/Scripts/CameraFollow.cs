using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Player player;
    Transform playerTransform;
    [SerializeField] Vector3 cameraOffset;

    void Awake()
    {
        GetPlayer();
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void GetPlayer()
    {
        player = FindFirstObjectByType<Player>();
        if (player != null)
            playerTransform = player.GetComponent<Transform>();
    }

    void FollowPlayer()
    {
        if (playerTransform != null)
            transform.position = new Vector3(playerTransform.position.x + cameraOffset.x, playerTransform.position.y + cameraOffset.y, cameraOffset.z);
    }
}
