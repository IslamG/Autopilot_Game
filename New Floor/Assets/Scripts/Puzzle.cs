using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour, IPuzzle
{
    [SerializeField]
    protected List<Puzzle> PreReq;
    [SerializeField]
    protected PopUpGen popUpGen;
    [SerializeField]
    protected TaskMenu taskMenu;

    protected bool isActive = false, isSolved = false;
    protected Task task;
    protected CheckpointPivot exposition;

    //protected OnHaulmarkReachedEvent haulmarkReached = new OnHaulmarkReachedEvent();
    public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsSolved { get => isSolved; }
    public bool IsEnabled { get; set; } = true;

    //public void AddListener(UnityAction<Puzzle> handler)
    //{
    //    haulmarkReached.AddListener(handler);
    //}
    public void Initialize()
    {
       // EventManager.AddInvoker(this);
        task = gameObject.GetComponent<Task>();
        if (task != null)
            Debug.Log("Puzzle start task: " + task.TaskText + " called from " + gameObject.name);
        exposition = gameObject.GetComponent<CheckpointPivot>();
    }
    protected virtual void Start()
    {
        Initialize();
    }
    //Unlock/make active item to access puzzle game
    public void CheckRequisites()
    {
        int step = 0;
        //if is leaf item unlock
        if (PreReq.Count == 0)
        {
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
        //if (IsActive)
        //{
        //    CheckItem();
        //}

    }
    //Puzzle Piece can only be solved if is active
    //Replace with puzzle game code or call
    public virtual void Activate()
    {
        if (!isActive)
        {
            isActive = true;
            //Invokes task listeners
            if (task != null)
                task.ActivateTask();
            if (exposition != null)
            {
                //exposition.StartHintDisplay();
            }
        }
        
        //Hides cosmatic arrow in scene, invokes path activated listeners
        //arrow.SetActive(false);
        //pathActivated.Invoke(JeremyPath.instance);

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




        //return true;
    }
    public virtual void Solve()
    {
        if (IsEnabled && !isSolved)
        {
            Task task = gameObject.GetComponent<Task>();
            isSolved = true;
            if (task != null)
            {
                task.IsCompleted = true;
                task.Deactivate();
                taskMenu.RemoveTaskFromList(task);
                Debug.Log("Is solving task: " + task.TaskText);
            }
            //IsEnabled = false;
            //this.enabled = false;
        }

    }
    protected void OnMouseDown()
    {
        if (IsEnabled)
        {
            //check if item is unlocked (leaf or solved)
            CheckRequisites();
            Debug.Log("Puzzle Mouse from " + gameObject);

        }

    }
    public void CheckItem()
    {
        if (IsActive)
        {
            //Call puzzle game normally
            //Puzzle();
            //Solve();
        }
    }
}
