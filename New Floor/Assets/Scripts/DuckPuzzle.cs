using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DuckPuzzle : Puzzle
{
    [SerializeField]
    Camera duckCamera, controlCamera, screenCamera;
    [SerializeField]
    GameObject duckPlane, screenPlane, datashowHolder;
    [SerializeField]
    FirstPersonController fps;

    Vector2 duckCamSize, controlCamSize;

    protected override void Start()
    {
        base.Start();
        float duckCamNum = duckCamera.orthographicSize * 2;
        duckCamSize = new Vector2(duckCamera.scaledPixelHeight / duckCamNum,
            duckCamera.scaledPixelWidth / duckCamNum);
        controlCamSize = new Vector2(screenPlane.transform.localScale.x,
            screenPlane.transform.localScale.y);
    }
    private new void OnMouseDown()
    {
        //DoTheThing();
        //base.OnMouseDown();
        fps.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        datashowHolder.SetActive(true);
    }
    private void DoTheThing()
    {
        //Vector3 point = Vector3.zero;
        Plane screen = new Plane(Vector3.up, new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z));
        Ray ray = controlCamera.ScreenPointToRay(Input.mousePosition);

        if (screen.Raycast(ray, out float distance))
        {
            Vector3 hit = ray.GetPoint(distance);
            //if (hit.collider.gameObject.name == "ScreenDisplay")
            //{
            Vector2 localCursor = hit;
            /*Rect r = GetComponent<RectTransform>().rect;

            //Using the size of the texture and the local cursor, clamp the X,Y coords between 0 and width - height of texture
            float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
            float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);

            //Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height
            float recalcX = coordX / tex.width;
            float recalcY = coordY / tex.height;

            localCursor = new Vector2(recalcX, recalcY);*/
            Debug.Log("local x= " + localCursor.x + " y= " + localCursor.y + " " + localCursor.normalized);
            //CastMiniMapRayToWorld(localCursor);
            //}
        }
    }
}
