using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 offset;
    [Range(0, 1f)]
    [SerializeField] float smoothTime;
    Vector3 Velocity;
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.position + offset, ref Velocity, smoothTime);
    }
}
