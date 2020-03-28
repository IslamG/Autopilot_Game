using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
    public GameObject snapper;
    float oldEulerAngles;
 
     void Start(){
          oldEulerAngles = transform.rotation.eulerAngles.x;
     }
 
     void OnMouseDown(){
          if (Mathf.Abs(oldEulerAngles - transform.rotation.eulerAngles.x)<0.5f){
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            //NO ROTATION
        } else{
                if (snapper.transform.localPosition.z > 1.80)
                {
                    snapper.transform.Translate(0, 0, -0.02f);
                }
          }
        
        }
    private void OnMouseUp() {
        transform.eulerAngles = new Vector3(0, 0, 0);
        snapper.transform.Translate(0, 0, 0.02f);
    }

}