using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToScreen : MonoBehaviour
{
    [SerializeField]
    GameObject screen;
    [SerializeField]
    Camera outputCam;
    [SerializeField]
    RenderTexture tex;

    Camera cam;
    Ray ray;
    Transform screenTransform;

    void Start()
    {
        cam = Camera.main;
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
        //Plane screen = new Plane(Vector3.up, new Vector3(gameObject.transform.position.x, 
            //gameObject.transform.position.y, gameObject.transform.position.z));
        ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;
        //simply initializing vector3 point, nothing else, this vector zero does nothing
        Vector3 point = Vector3.zero;
        
        if (Physics.Raycast(ray, out RaycastHit hit, 3))
        {
            if (hit.collider.gameObject.name == "ScreenDisplay")
            {
                //Debug.Log("did hit "+ hit.collider.gameObject+ " at "
                //    +hit.point);
                outputCam.ViewportPointToRay(hit.point);
                //Debug.Log("is "+RectTransformUtility.RectangleContainsScreenPoint((RectTransform)screenTransform,hit.point));
                //Texture tex = GetComponent<RawImage>().texture;
                Vector2 localCursor = hit.point;
                Rect r = GetComponent<RectTransform>().rect;

                //Using the size of the texture and the local cursor, clamp the X,Y coords between 0 and width - height of texture
                float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
                float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);

                //Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height
                float recalcX = coordX / tex.width;
                float recalcY = coordY / tex.height;

                localCursor = new Vector2(recalcX, recalcY);
               // Debug.Log("local " + localCursor);
                CastMiniMapRayToWorld(localCursor);
            }
        }
        return point;
    }
    


    private void CastMiniMapRayToWorld(Vector2 localCursor)
    {
        Ray miniMapRay = outputCam.ScreenPointToRay(new Vector2(localCursor.x * outputCam.pixelWidth, localCursor.y * outputCam.pixelHeight));//ScreenPointToRay
        RaycastHit miniMapHit;
        if (Physics.Raycast(miniMapRay, out miniMapHit, 5f))
        {
            //Debug.DrawRay(outputCam.transform.position,Vector3.down, Color.green, Mathf.Infinity);
            Debug.DrawLine(outputCam.transform.position,Vector3.down, Color.red);// outputCam.transform.up
            Debug.Log("something");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("miniMapHit: " + miniMapHit.collider.gameObject);
            }
            
        }

    }
}
