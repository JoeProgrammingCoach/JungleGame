using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXPosition : MonoBehaviour
{
    [SerializeField] float minimumX, maximumX;
    void Awake()
    {
        transform.position = new Vector2(Random.Range(minimumX, maximumX), transform.position.y);
    }

   
}
