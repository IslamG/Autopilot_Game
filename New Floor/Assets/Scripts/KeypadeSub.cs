using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadeSub : MonoBehaviour
{
    [SerializeField]
    Elevator elevator;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.green);
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj == gameObject)
            {
                elevator.SequenceAction();
            }
            

        }
    }
}
