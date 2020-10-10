using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarthasDecision : PathStarter
{
    [SerializeField]
    Transform acceptLocation, declineLocation;
    bool decision=false, tried=false;

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
        
    }

    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
        //Hides cosmatic arrow in scene, invokes path activated listeners

         arrow.SetActive(false);
         pathActivated.Invoke(JeremyPath.instance);        
        
        //tbd show text outlining the task on activation 

        //PopUp pop = gameObject.GetComponent<PopUp>();
        //pop.MessageHeader = task.TaskText;
        //pop.ShowPop();

        //fpc.enabled = false;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;


        //tbd generic puzzle delegate method for pop up

        //popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        //popUpGen.gameObject.SetActive(true);


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
