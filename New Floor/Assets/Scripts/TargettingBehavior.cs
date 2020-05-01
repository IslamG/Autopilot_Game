﻿using System.Collections;
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
    //When NPC is too close to an object
    private void OnTriggerEnter(Collider other)
    {
        //transform.position -= transform.forward * speed * Time.deltaTime;
        inRange = true;
    }
    //When NPC leaves range
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
    //Continue moving towards target
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
