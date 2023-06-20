using UnityEngine;

public class Rotator : MonoBehaviour
{
    const float rotateSpeed = 1f;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
