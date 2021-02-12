using UnityEngine;

public class BlindsFold : MonoBehaviour
{
    [SerializeField]
    private GameObject nextBlind;

    private float startPos;
    private bool clicked = false;

    //Store start position
    void Start()
    {
        startPos = transform.localPosition.y;
    }
    //Control the movement on click and release
    void OnMouseDown()
    {
        clicked = true;
    }
    void OnMouseUp()
    {
        clicked = false;
    }

    // Add force when being pulled
    void Update()
    {
        if (clicked)
        {
            _ = Mathf.Abs(transform.position.y - startPos);
            nextBlind.GetComponent<Rigidbody>().AddForce(0, 3f, 0);
        }
    }
}
