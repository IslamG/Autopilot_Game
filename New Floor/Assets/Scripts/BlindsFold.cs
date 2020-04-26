using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindsFold : MonoBehaviour
{
    public GameObject nextBlind;
    private float startPos;
    private bool clicked = false;

    void Start()
    {
        startPos = transform.localPosition.y;
    }
    void OnMouseDown()
    {
        clicked = true;
    }
    void OnMouseUp()
    {
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            _ = Mathf.Abs(transform.position.y - startPos);
            //.transform.Translate(0, +distance, 0, Space.Self);
            nextBlind.GetComponent<Rigidbody>().AddForce(0, 3f, 0);
            //Debug.Log(distance);
        }
        //if (distance <= Mathf.Floor( 0.03f)){
        //    Debug.Log("Is less");
        //}


    }
}
