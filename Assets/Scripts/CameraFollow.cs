using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _player;
    public Vector3 _offset;

    void Update()
    {
        transform.position = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, _offset.z); // Camera follows the player with specified offset positio
    }
}
