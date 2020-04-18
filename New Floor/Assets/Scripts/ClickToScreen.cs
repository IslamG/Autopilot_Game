using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToScreen : MonoBehaviour
{
    public GameObject screen;
    public Camera cam;
    private float screenBounds;
    //private Plane screen;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
         //screen = screenObj.GetComponent<Plane>();
    }
    
    // Update is called once per frame
    void Update()
    {
        /*ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray))
            Debug.Log(Input.mousePosition);*/
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
        //Debug.Log(Input.mousePosition);
        /*if (screen.Raycast(ray, out distance))
        {
            point = ray.GetPoint(distance);
        }*/
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null)
            {
                //RaycastReturn = hit.collider.gameObject.name;
                //FoundObject = GameObject.Find(RaycastReturn);
                //Destroy(FoundObject);
                Debug.Log("did hit "+ hit.collider.gameObject+ " at "
                    +hit.point);
            }
        }
        return point;
    }
}
