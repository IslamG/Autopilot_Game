using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewableCellphone : Puzzle
{
    [SerializeField]
    GameObject cellSpot;
    [SerializeField]
    Camera cellCam;
    [SerializeField]
    RenderTexture cellView;
    [SerializeField]
    RawImage cellFocus;
    [SerializeField]
    GameObject[] focusObjects;
    [SerializeField]
    Material[] collectables;


    private bool isHeld = false, isFocused;
    private Dictionary<GameObject, Material> targetPairs=  
        new Dictionary<GameObject, Material>();
    private GameObject currentObj;
    private List<GameObject> usedObjs= new List<GameObject>();

    //Add collectable materials as value to collectable objects key
    //Consider changing arrays to lists, to pop used objects later
    private void Start()
    {
        for(int i=0; i < focusObjects.Length; i++)
        {
            targetPairs.Add(focusObjects[i], collectables[i]);
        }
    }

    //When clicked transfer to viewable cell location
    //Disable gravity and collider so it doesn't fall or move
    //Parent to spot so it moves with the character
    private new void OnMouseDown()
    {
        //if (isActive)
        //{
            //cellCam.gameObject.SetActive(true);
            gameObject.transform.position = cellSpot.transform.position;
            gameObject.transform.eulerAngles = cellSpot.transform.eulerAngles; //new Vector3(-2, 0, -68);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.parent = cellSpot.transform;
            isHeld = true;
            Activate();
        //}
        
    }
    void Update()
    {
        //Take picture using Q
        if (isHeld && Input.GetKeyDown("e"))
        {
            StartCoroutine(TakePic());
        }
        //Drop cellphone with mouse right click
        //reinable gravity and colliders and clear parent
        if (isHeld && Input.GetMouseButton(1))
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            isHeld = false;
        }
        if (isHeld)
        {
            //Check if cellphone camera is pointed at a photographic object
            Ray ray = new Ray(cellCam.transform.position, cellCam.transform.forward); //cellCam.ScreenPointToRay(cellCam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f))
            {
                //Check if we're mousing over an object we can focus
                Debug.DrawRay(cellCam.transform.position, cellCam.transform.forward, Color.green);
                foreach (GameObject obj in focusObjects)
                {
                    //If we'er over an object we can focus and it's not already photographed
                    if (hit.transform.gameObject == obj && !usedObjs.Contains(obj))
                    {
                        //If isn't already displaying focus icon, turn icon on
                        if (!isFocused)
                        {
                            cellFocus.color=new Color(65, 255, 0);
                        }
                        isFocused = true;
                        currentObj = obj;
                    }
                    
                }
            }else{
                  //If is displaying focus icon, turn icon off
                  if (isFocused)
                  {
                       cellFocus.color = Color.red;
                       isFocused = false;
                  }
            }
        }
    }
    /* Disable camera temporarily to have a visual effect on 
     * the render texture of the image freezing
     * play shutter sound
     * call the screenshot class
     * then reinable cell camera
     */
    private IEnumerator TakePic() 
    {
        cellCam.enabled = false;
        gameObject.GetComponentInChildren<AudioSource>().Play();
        ScreenshotHandler.TakeScreenshot_Static(300, 300);
        yield return new WaitForSecondsRealtime(1f);
        cellCam.enabled = true;
        cellCam.targetTexture = cellView;
        
        //If the photograph taken was of a collectable object
        //load into image texture
        if (isFocused)
        {      
            StartCoroutine(LoadImage());
        }
        else
        {
            //When not a target object show negative feedback
            yield break;
        }
    }
    //Load image from location on disk
    //set the pair object key/value with the image as a texture
    //mark object as photographed
    IEnumerator LoadImage()
    {
        WWW www = new WWW(Application.dataPath + "/CameraScreenshot.png");
        while (!www.isDone)
            yield return null;
        Material mat = targetPairs[currentObj];
        mat.SetTexture("_MainTex", www.texture);
        Debug.Log("Image " + www.texture.name + " p " + 
            mat.GetTexture("_MainTex").name);
        usedObjs.Add(currentObj);
        CheckFinish();
    }
    void CheckFinish()
    {
        if (usedObjs.Count == targetPairs.Count)
        {
            Solve();
            Debug.Log("Solving cellphone");
        }
    }
    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
        //tbd show text ou
        //PopUp pop = gameObject.GetComponent<PopUp>();
        //pop.MessageHeader = task.TaskText;
        //pop.ShowPop();

        //fpc.enabled = false;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;


        //tbd generic puzzle delegate method for pop up

        //popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        //popUpGen.gameObject.SetActive(true);




        //return true;
    }
}
