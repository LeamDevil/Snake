using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controls : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public Transform Player;


    void Update()
    {
        
        transform.Translate(direction.normalized * speed);
        if (Input.GetMouseButtonDown(0))
        {
            Player.Translate(-1f, 0, 0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Player.Translate(1f, 0, 0);
        }
        

    }
}
