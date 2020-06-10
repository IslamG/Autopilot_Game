using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Puzzle Path", menuName = "PuzzlePath", order = 52)]
//Sequencing of puzzle order 
//Each object is its own path that leads to a junction or ending
//tbd probably removed
public class PuzzlePath: ScriptableObject
{
    [SerializeField]
    PuzzlePiece[] pieces;
    //possible to be removed
    //tbd hold puzzle path progress

}
