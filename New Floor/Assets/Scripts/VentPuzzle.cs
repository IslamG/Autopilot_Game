using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPuzzle : Puzzle
{
    private new void OnMouseDown()
    {
        if (gameObject.name.Equals("Exit"))
        {
            Exit();
        }
        else
        {
            Activate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered vent by: "+other.gameObject.name);
        if (gameObject.name.Equals("Exit"))
        {
            Exit();
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Activate();
            }
        }
    }
    private void LoadOut()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    private void Exit()
    {
        //LevelTraversal.TargetLevel = "FloorTest";
    }

    public override void Activate()
    {
        if (isActive)
        {
            LoadOut();
        }

    }
}
