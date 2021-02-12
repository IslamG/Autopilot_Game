using UnityEngine;

//Make object face and follow target
//functionalty suspended
//tbd probably remove
public class TargettingBehavior : MonoBehaviour
{
    //possible remove
    //or replace with switching between animations
    public Transform target;
    public float speed = 2.5f;
    public bool moveable = false;

    private bool inRange = false;
    private Vector3 dir;

    private void Update()
    {
        //transform.LookAt(gameObject.transform.position);
        //transform.rotation=Quaternion.LookRotation(target.position);
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
        if (moveable)
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
            dir = transform.position * -1;
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
