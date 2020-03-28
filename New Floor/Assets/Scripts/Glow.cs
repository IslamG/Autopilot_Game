using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public Material glowMat;
    private bool onOff = false;
    private Material[] origMaterials;

    /*private void Awake()
    {
        origMaterials = GetComponent<Renderer>().materials;
    }*/
    private void OnMouseDown()
    {
        glow(gameObject);
    }
    public void glow(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        onOff = !onOff;
        if (onOff)
        {
            renderer.material = glowMat;
        }
        else
        {
            Material[] currentlyAssignedMaterials = renderer.materials;
            Destroy(currentlyAssignedMaterials[0]);
            renderer.materials = origMaterials;
            Debug.Log("Glow");
        }
    }
}
