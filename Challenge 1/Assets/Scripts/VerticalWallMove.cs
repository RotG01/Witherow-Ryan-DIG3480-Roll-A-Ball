using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallMove : MonoBehaviour
{

    public float speed = 2.5f;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, 14) - 7);
    }
}
