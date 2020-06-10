using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script blendshape animation
//tbd probably remove
public class LiquidDeform : MonoBehaviour
{
    private float mShape = 0.0f;

    void Start()
    {
        //Constantly animate
        InvokeRepeating("SimpleDeform", 0.0f, 0.01f);
    }

    void SimpleDeform()
    {
        //Dynamicaly change blendshape value between 0 and 100
        if (mShape >= 100.0f)
        {
            //CancelInvoke("SimpleDeform");
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, 0);
            //InvokeRepeating("SimpleDeform", 0.0f, 0.01f);
        }
        Debug.Log(mShape);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mShape++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mShape++);
    }
}
