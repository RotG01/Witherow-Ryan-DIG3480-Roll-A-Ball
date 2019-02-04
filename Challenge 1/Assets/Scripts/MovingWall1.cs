using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall1 : MonoBehaviour
{

    public float speed = 2f;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 14) - 7, transform.position.y, transform.position.z);
    }
}
