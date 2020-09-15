using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    private List<PuzzlePiece> PreReq;//, List<Puzzle> puzzleList;
    [SerializeField]
    private FirstPersonController fpc;
    [SerializeField]
    PopUpGen popUpGen;
    [SerializeField]
    private bool isPathStarter;
    [SerializeField]
    private GameObject arrow;

    private bool isActive = false, isSolved = false;

    public bool IsActive { get => isActive;}
    public bool IsSolved { get => isSolved;}
    public OnPathActivated pathActivated = new OnPathActivated();
    //public OnPathActivated puzzleActivated = new OnPathActivated();

    private void Start()
    {
        EventManager.AddInvoker(this);
    }

    //Unlock/make active item to access puzzle game
    private void CheckRequisites()
    {
        int step = 0;
        //if is leaf item unlock
        if (PreReq.Count == 0)
        {
            Debug.Log("Pre req = zero");
            Activate();
        }
        //else if all prerequisites are met unlock
        else
        {
            foreach (PuzzlePiece item in PreReq)
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
    }
    //Puzzle Piece can only be solved if is active
    //Replace with puzzle game code or call
    private void Solve ()
    {
        char pathId = gameObject.GetComponent<Task>().TaskGroup;
        AdventurePath path=null;
        /*switch (pathId)
        {
            /*case 'm':
                {
                    MaisyPath.Instantiate(this.gameObject);
                    path = MaisyPath.instance;
                    
                    
                    break;
                }
            case 'j':
                {
                    path=JeremyPath.instance;
                    break;
                }
        }*/
        pathActivated.Invoke(JeremyPath.instance);

    }
    private void Puzzle()
    {
        if (IsActive)
        {
            //do puzzle
            //if done correctly
            //Solve();
            Debug.Log("Puzzling");
        }
    }
    private void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task=gameObject.GetComponent<Task>();
        task.ActivateTask();
        if (isPathStarter)
        {
            arrow.SetActive(false);
        }
        //tbd show text outlining the task on activation 

        /*PopUp pop = gameObject.GetComponent<PopUp>();
        pop.MessageHeader = task.TaskText;
        pop.ShowPop();

        fpc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        */ 

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
    }
    private void OnMouseDown()
    {
        //check if item is unlocked (leaf or solved)
        CheckRequisites();
        if (IsActive)
        {
            CheckItem();
        }
    }
    private void CheckItem()
    {
        if (IsActive)
        {
            //Call puzzle game normally
            Puzzle();
            Solve();
        }
    }
    //Possibly remove?
    /*public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }*/
    public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }
}
