using UnityEngine;

public class MarthasDecision : PathStarter
{
    [SerializeField]
    Transform acceptLocation, declineLocation;
    [SerializeField]
    GameObject arrow;

    bool decision = false, tried = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DropSpot>() != null)
        {
            if (!tried)
            {
                if (Random.Range(0, 2) != 0)
                {
                    decision = true;
                }
                DecisionReached();
                tried = true;
            }
            Debug.Log("Persistant aren't we");
        }
    }
    private void DecisionReached()
    {
        if (decision)
        {
            gameObject.transform.position = acceptLocation.position;
        }
        else
        {
            gameObject.transform.position = declineLocation.position;
        }
        Solve();
    }

    public override void Activate()
    {
        base.Activate();
        arrow.SetActive(false);
        pathActivated.Invoke(JeremyPath.instance);

        //Activate drop spot for tasks with drop spots
        DropItem di = gameObject.GetComponent<DropItem>();
        //if dropppable object
        if (di != null && !task.IsCompleted)
        {
            foreach (DropSpot spot in di.TargetSpot)
            {
                //di.TargetSpot
                spot.gameObject.SetActive(true);
            }
        }

        //return true;
    }
}
