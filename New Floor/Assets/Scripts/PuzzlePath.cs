using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Puzzle Path", menuName = "PuzzlePath", order = 52)]
public class PuzzlePath: ScriptableObject
{
    [SerializeField]
    PuzzlePiece[] pieces;
    //possible to be removed
    //tbd hold puzzle path progress

}
