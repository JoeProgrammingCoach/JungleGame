using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        WorldSpaceDifference();
    }

    void WorldSpaceDifference()
    {
        offset = transform.position - player.position;
    }
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
