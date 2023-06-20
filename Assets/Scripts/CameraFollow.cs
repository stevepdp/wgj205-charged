using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraOffset;

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x + cameraOffset.x, player.position.y + cameraOffset.y, cameraOffset.z);
    }
}
