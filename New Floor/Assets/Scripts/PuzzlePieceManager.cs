﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) // or whatever range, if applicable
            {
                PuzzlePiece hitPiece = hit.transform.gameObject.GetComponent<PuzzlePiece>();
                if ( hitPiece != null)
                {
                    //Debug.Log("Clicked= " + hitPiece.name + " isSolved= " + hitPiece.IsSolved() + " isActive= " + hitPiece.IsActive());
                    CheckItem(hitPiece);
                }
                else
                {
                    //Debug.Log("not hit");
                }
            }
            else
            {
                //Debug.Log("out of range");
                // You didn't click on anything.
                // Either out of range or empty skybox behind mouse cursor
            }
        }
    }

    private void CheckItem(PuzzlePiece hitPiece)
    {
        if (hitPiece.IsActive())
        {
            //Call puzzle game normally
            //Debug.Log("clicked is " + hitPiece.name);
            hitPiece.Puzzle();
            hitPiece.Solve();
        }
        else
        {
            //Unlock if pre requistes are solved
            bool isUnlocked = hitPiece.Unlock();
            if (isUnlocked)
            {
                CheckItem(hitPiece);
            }
            else
            {
                //Debug.Log("Item is locked");
            }
        }
    }
}
