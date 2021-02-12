using System.Collections.Generic;
using UnityEngine;

//Keep track of and manage puzzles in the level
//tbd probably removed
public class PuzzlePieceManager : MonoBehaviour
{
    List<Puzzle> puzzles = new List<Puzzle>();

    public void SetPuzzles()
    {
        //load
        foreach (Puzzle puzzle in puzzles)
        {
            //if loaded active set active
        }
    }
}
