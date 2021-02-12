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
    /*
     * Unity counts the collider of children object as part of 
     * parent object colliders, therefor trigger colliders can fire on  
     * both parent and child objects either way, even with seperate scripts
     * so it's important to check the name of the object firing the trigger
     */
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Equals("PaperCup") && other.name.Equals("Liquid") && !HasCoffee)
        {
            Filled();
            Debug.Log("Cup spill hit: " + other.name);
        }
        if (gameObject.name.Equals("PaperCup") && other.name.Equals("Building") && HasCoffee)
        {
            Spilled();
        }
    }
}
