using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    private List<PuzzlePiece> PreReq;//, List<Puzzle> puzzleList;
    private bool isActive = false, isSolved = false;

    public bool IsActive { get => isActive;}
    public bool IsSolved { get => isSolved;}

    //Unlock/make active item to access puzzle game
    private void CheckRequisites()
    {
        int step = 0;
        //if is leaf item unlock
        if (PreReq.Count == 0)
        {
            Debug.Log("Pre req = zero");
            Activate();
        }
        //else if all prerequisites are met unlock
        else
        {
            foreach (PuzzlePiece item in PreReq)
            {
                step++;
                if (!item.IsSolved)
                {
                    step = 0;
                }
            }
            if (step == PreReq.Count)
            {
                Activate();
            }
        }
    }
    //Puzzle Piece can only be solved if is active
    //Replace with puzzle game code or call
    private void Solve ()
    {       
    }
    private void Puzzle()
    {
        if (IsActive)
        {
            //do puzzle
            //if done correctly
            //Solve();
            Debug.Log("Puzzling");
        }
    }
    private void Activate()
    {
        isActive = true;
        gameObject.GetComponent<Task>().ActivateTask();
        DropSpot ds = gameObject.GetComponent<DropSpot>();
        if (ds != null)
        {
            ds.TargetSpot.SetActive(true);
        }
            
        //return true;
    }
    private void OnMouseDown()
    {
        //check if item is unlocked (leaf or solved)
        CheckRequisites();
        if (IsActive)
        {
            CheckItem();
        }
    }
    private void CheckItem()
    {
        if (IsActive)
        {
            //Call puzzle game normally
            Puzzle();
            Solve();
        }/*
        else
        {
            //Unlock if pre requistes are solved
            bool isUnlocked = Unlock();
            if (isUnlocked)
            {
                CheckItem();
            }
            else
            {
                Debug.Log("Item is locked");
            }
        }*/
    }
}
