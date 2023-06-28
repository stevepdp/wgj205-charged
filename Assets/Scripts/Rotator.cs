using UnityEngine;

public class Rotator : MonoBehaviour
{
    const float ROTATE_SPEED = 1f;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, ROTATE_SPEED, 0, Space.World);
    }
}
