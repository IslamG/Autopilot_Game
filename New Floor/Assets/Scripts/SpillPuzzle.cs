using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillPuzzle : Puzzle
{
    [SerializeField]
    GameObject coffeeBlock, coffeeStain;
    [SerializeField]
    DoorScript storageDoor;

    public bool HasCoffee { get; set; } = false;

    private void Filled()
    {
        gameObject.GetComponent<AudioSource>().Play();
        HasCoffee = true;
        coffeeBlock.SetActive(true);
    }
    private void Spilled()
    {
        coffeeBlock.SetActive(false);
        coffeeStain.SetActive(true);
        coffeeStain.transform.position = gameObject.transform.position;
        gameObject.transform.eulerAngles = new Vector3(0, 90f, 0);
        storageDoor.SetLock(false);
        this.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Liquid") && !HasCoffee)
        {
            Filled();
        }
        if (other.name.Equals("Building") && HasCoffee)
        {
            Spilled();
        }
    }
    protected override void Activate()
    {
        throw new System.NotImplementedException();
    }
}
