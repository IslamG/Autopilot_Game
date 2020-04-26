using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public List<PuzzlePiece> PreReq;
    private bool isActive, solved;

    private void Start()
    {
        isActive = false;
        solved = false;
        //check if item is unlocked on start (leaf or solved)
        Unlock();
    }
    //Unlock/make active item to access puzzle game
    public bool Unlock()
    {
        int step = 0;
        //if is leaf item unlock
        if (PreReq.Count == 0)
        {
            isActive = true;
            //Debug.Log("Unlocking " + this.name);
            return true;
        }
        //else if all prerequisites are met unlock
        else
        {
            foreach (PuzzlePiece item in PreReq)
            {
                step++;
                //Debug.Log("outerloop "+item.name+" issolved "+item.IsSolved());
                if (!item.IsSolved())
                {
                   // Debug.Log("checking prereq " + item.name + " issolved= " + item.IsSolved());
                    step = 0;
                    return false;
                    //break;
                }
            }
            if (step == PreReq.Count)
            {
                isActive=true;
                //Debug.Log("Unlocking " + this.name);
                return true;
            }
            //Debug.Log("Reached outer loop");
            return false;
        }
    }
    //Return active state
    public bool IsActive()
    {
        return isActive;
    }
    //Puzzle Piece can only be solved if is active
    public void Solve ()
    {
        //Replace with puzzle game code or call
        solved = true;
        //Debug.Log("now solved " + this.name);
        
    }
    //Return solved state
    public bool IsSolved()
    {
        return solved;
    }
    public void Puzzle()
    {
        if (IsActive())
        {
            //do puzzle
            //if done correctly
            //Solve();
            //Debug.Log("inside puzzle "+ this.name);
        }
        else
        {
            Unlock();
        }
    }
}
