using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
    [SerializeField]
    private bool isLocked;

    private GameObject snapper;
    Vector3 oldEulerAngles;
 
    void Start(){
        oldEulerAngles = transform.localEulerAngles;
        if(gameObject.transform.Find("snapper")!=null)
            snapper= gameObject.transform.Find("snapper").gameObject;
        if (isLocked)
        {
            GameObject door=gameObject.transform.parent.gameObject;
            door.GetComponent<Rigidbody>().constraints = 
                RigidbodyConstraints.FreezeRotation;
        }
    }
    //When door clicked
    void OnMouseDown(){
       //When door rotation ~= 0 stop door (closing it)
         if (Mathf.Abs(oldEulerAngles.x - transform.rotation.eulerAngles.x)<0.5f){

            //Removing any force from the door so it doesn't swing
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            
         } else{//When door moved and not closed, pull snapper in
            if (snapper != null)
            {
                if (snapper.transform.localPosition.z > 1.80)
                {
                    snapper.transform.Translate(0, 0, -0.02f);
                }
            }
                
         }
    }
    private void OnMouseUp() {
        //When mouse released return snapper outwards
        if (snapper != null)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            snapper.transform.Translate(0, 0, 0.02f);
        }
        else
        {
            if (Mathf.Abs(oldEulerAngles.y - transform.rotation.eulerAngles.y) < 0.5f)
            {

                //Removing any force from the door so it doesn't swing
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                transform.localEulerAngles = oldEulerAngles;

            }
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name.ToLower();
        Debug.Log(name);
        if (name.Contains("stalls"))
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.localEulerAngles = oldEulerAngles;
        }
        
    }
}