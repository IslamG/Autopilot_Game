using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsControl : MonoBehaviour
{
    private SpriteRenderer tipRenderer;
    [SerializeField]
    private Sprite[] sprites;

    public void GenerateTip()
    {
        int index = Random.Range(0, sprites.Length);
        tipRenderer.sprite = sprites[index];
    }

}
