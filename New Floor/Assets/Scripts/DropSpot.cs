using UnityEngine;

public class DropSpot : MonoBehaviour
{
    //tbd better system trade-off between object and spot
    [SerializeField]
    GameObject[] targetObject;

    [SerializeField]
    VentPuzzle vent;

    private bool fired = false, isTarget=false;

    //If correct object placed inside of drop spot
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObj = other.gameObject;
        foreach(GameObject item in targetObject)
        {
            if (item == otherObj)
            {
                isTarget = true;
                break;
            }
        }
        if (isTarget)//!fired && 
        {
            Debug.Log("depositied item");
            fired = true;
            isTarget = false;
            //tbd add reaction to successful deposite
            //possibly change remove system

            //Disable drop spot and item scripts

            OtherDisable(other.gameObject);
            DropSpot[] allSpots = other.gameObject.GetComponent<DropItem>().TargetSpot;
            foreach (DropSpot spot in allSpots)
            {
                if (spot.gameObject != gameObject)
                {
                    spot.gameObject.SetActive(false);
                }
            }
            if (vent != null)
            {
                if (Package.PackageOpened)
                {
                    vent.IsActive = true;
                }
            }
            Debug.Log("Drop spot trigger enter other puzzle " + other.GetComponent<Puzzle>());
            if (!other.name.Contains("Figurine"))
            {
                if(other.GetComponent<Puzzle>()!=null)
                    other.GetComponent<Puzzle>().Solve();
            }
                
            this.gameObject.SetActive(false);
        }
        else
        {//???
            Collider[] col = gameObject.GetComponents<Collider>();
            foreach (Collider bump in col)
            {
                if (!bump.isTrigger)
                {
                    bump.enabled = false;
                }
            }
        }
    }
    //???
    private void OnTriggerExit(Collider other)
    {
        CapsuleCollider[] col = gameObject.GetComponents<CapsuleCollider>();
        foreach (CapsuleCollider bump in col)
        {
            if (!bump.isTrigger)
            {
                bump.enabled = true;
            }
        }
    }
    //Called when completed
    private void OtherDisable(GameObject otherObj)
    {
        DropItem drop = otherObj.GetComponent<DropItem>();
        //If a collectable is found, trigger the collection event
        if (drop.IsCollectable)
        {
            drop.itemFound.Invoke(drop);
        }
        drop.enabled = false;
    }

}
