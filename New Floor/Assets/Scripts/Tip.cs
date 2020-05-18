using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tip", menuName = "Tip", order = 51)]
public class Tip : ScriptableObject
{
    public Sprite TipSprite { get; set; } 
    public string DisplayText { get; set; }
    public bool WasDisplayed { get; set; }
}
