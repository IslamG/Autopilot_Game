using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargettingBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 2.5f;
    private bool inRange = false;
    private Vector3 dir;

    private void Update()
    {
        transform.LookAt(target);
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        //transform.position -= transform.forward * speed * Time.deltaTime;
        inRange = true;
        Debug.Log("In range");
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        Debug.Log("Out of range");
    }
    private void Move()
    {
        int amount;
        if (inRange)
        {
            dir = transform.position *-1;
            amount = 4;
        }
        else
        {
            dir = transform.position;
            amount = 1;
        }
        transform.position = Vector3.MoveTowards(dir, target.position, speed * amount);//+= dir * speed * Time.deltaTime * amount;
    }
}
