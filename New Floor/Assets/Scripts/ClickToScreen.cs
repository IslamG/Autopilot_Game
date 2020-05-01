using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToScreen : MonoBehaviour
{
    public GameObject screen;
    public Camera cam;
    Ray ray;
    Transform screenTransform;

    void Start()
    {
        screenTransform = screen.transform;
        Debug.Log("Screen: "+screenTransform);
    }
    
    void Update()
    {
        getCursorWorldPosition();
    }

    Vector3 getCursorWorldPosition()
    {
        //finding point in world in cursor position
        Plane screen = new Plane(Vector3.up, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
        ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;
        //simply initializing vector3 point, nothing else, this vector zero does nothing
        Vector3 point = Vector3.zero;
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.name == "screenDisplay")
            {
                Debug.Log("did hit "+ hit.collider.gameObject+ " at "
                    +hit.point);
                Debug.Log(RectTransformUtility.RectangleContainsScreenPoint((RectTransform)screenTransform,hit.point));
            }
        }
        return point;
    }
}
