using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField]
    protected List<Puzzle> PreReq;
    [SerializeField]
    protected PopUpGen popUpGen;

    protected bool isActive = false, isSolved = false;

    public bool IsActive { get => isActive;}
    public bool IsSolved { get => isSolved;}

    //Unlock/make active item to access puzzle game
    protected void CheckRequisites()
    {
        int step = 0;
        //if is leaf item unlock
        if (PreReq.Count == 0)
        {
            Debug.Log("Pre req = zero source: " + name);
            Activate();
        }
        //else if all prerequisites are met unlock
        else
        {
            foreach (Puzzle item in PreReq)
            {
                step++;
                if (!item.IsSolved)
                {
                    step = 0;
                }
            }
            if (step == PreReq.Count)
            {
                Activate();
            }
        }
        if (IsActive)
        {
            CheckItem();
        }

    }
    //Puzzle Piece can only be solved if is active
    //Replace with puzzle game code or call
    /*private void Solve ()
    {
        
    }*/
    /*private void Puzzle()
    {
        if (IsActive)
        {
            //do puzzle
            //if done correctly
            //Solve();
            Debug.Log("Puzzling source: "+name);
        }
    }*/
    protected abstract void Activate();
        /*
            //Activate task based on attached task 
            isActive = true;
            Task task=gameObject.GetComponent<Task>();
            //Invokes task listeners
            task.ActivateTask();
            //Hides cosmatic arrow in scene, invokes path activated listeners
            if (isPathStarter)
            {
                arrow.SetActive(false);
                pathActivated.Invoke(JeremyPath.instance);
            }
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
                foreach(DropSpot spot in di.TargetSpot)
                {
                    //di.TargetSpot
                    spot.gameObject.SetActive(true);
                }          
            }

            //return true;
            */
    
    protected void OnMouseDown()
    {
        Debug.Log("Calling puzzle active checker, source: " + gameObject.name +" / "+name);
        //check if item is unlocked (leaf or solved)
        CheckRequisites(); 
    }
    protected void CheckItem()
    {
        if (IsActive)
        {
            //Call puzzle game normally
            //Puzzle();
            //Solve();
        }
    }
}
