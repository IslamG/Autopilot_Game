using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField]
    protected List<Puzzle> PreReq;
    [SerializeField]
    protected PopUpGen popUpGen;
    [SerializeField]
    protected TaskMenu taskMenu;

    protected bool isActive = false, isSolved = false;

    public bool IsActive { get => isActive; set => isActive=value; }
    public bool IsSolved { get => isSolved;}
    public bool IsEnabled { get; set; } = true;

    //Unlock/make active item to access puzzle game
    protected void CheckRequisites()
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
    protected abstract void Activate();
    public virtual void Solve()
    {
        if (IsEnabled)
        {
        Task task = gameObject.GetComponent<Task>();
            isSolved = true;
            task.IsCompleted = true;
            taskMenu.RemoveTaskFromList(task);
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
