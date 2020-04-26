using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject astroidPrefab;
    //private List<GameObject> astroidList= new List<GameObject>();
    private float radius, posX, posY;

    private void Start()
    {
        astroidPrefab= Instantiate(astroidPrefab) as GameObject;
        radius = astroidPrefab.GetComponent<CircleCollider2D>().radius;
        Vector2 location = new Vector2(ScreenUtils.ScreenLeft - (radius/2), 0);            
        astroidPrefab.GetComponent<Astroid>().Initialize(Direction.Right, location);

        astroidPrefab = Instantiate(astroidPrefab) as GameObject;
        location = new Vector2(ScreenUtils.ScreenRight + (radius / 2), 0);
        astroidPrefab.GetComponent<Astroid>().Initialize(Direction.Left, location);

        astroidPrefab = Instantiate(astroidPrefab) as GameObject;
        location = new Vector2(0, ScreenUtils.ScreenTop - (radius / 2));
        astroidPrefab.GetComponent<Astroid>().Initialize(Direction.Down, location);

        astroidPrefab = Instantiate(astroidPrefab) as GameObject;
        location = new Vector2(0, ScreenUtils.ScreenBottom + (radius / 2));
        astroidPrefab.GetComponent<Astroid>().Initialize(Direction.Up, location);
        //astroidList.Add(astroidPrefab);
    }
}
