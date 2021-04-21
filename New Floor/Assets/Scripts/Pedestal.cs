using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [SerializeField]
    GameObject dome, frame, doll, heart, package, doorFrame;
    private void OnMouseDown()
    {
        dome.SetActive(false);
    }
    //Load if path object is obtained
    //set active accordingly
    //Check if all are found
    //if yes activate subconscious ending
}
