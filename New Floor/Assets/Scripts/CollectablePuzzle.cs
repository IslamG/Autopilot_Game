using UnityEngine;

public class CollectablePuzzle : PathStarter
{
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    AdventurePath bossPath;

    //Possbily add dropstop specific puzzle type
    public override void Activate()
    {
        //if (!isActive)
        //{
            base.Activate();

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
        //}

    }
    public override void Solve()
    {
        base.Solve();
        bossPath.PathObjectEarned(bossPath, this);
    }

}
