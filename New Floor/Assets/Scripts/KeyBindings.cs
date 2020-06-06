using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindings : MonoBehaviour
{
    public static KeyBindings instance;
    static bool created = false;
    //Singleton
    void Awake()
    {
        if (!created)
        {
            created = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
    [SerializeField]
    private string[] wordList;
    [SerializeField]
    private TMP_Text[] labels;
    [SerializeField]
    private TMP_InputField[] fields;

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private void Start()
    {
        keys.Add("Jump", KeyCode.Space);
        keys.Add("Forward", KeyCode.W);
        keys.Add("Left", KeyCode.A);
        keys.Add("Back", KeyCode.S);
        keys.Add("Right", KeyCode.D);
        keys.Add("Use", KeyCode.Mouse0);
        keys.Add("Cancel", KeyCode.Mouse1);
        keys.Add("Task Menu", KeyCode.M);
        keys.Add("Pause Menu", KeyCode.Escape);
        int i = 0;
        foreach (KeyValuePair <string, KeyCode> key in keys)
        {
            labels[i].text = key.Key;
            fields[i].text = key.Value.ToString();
            i++;
        }
    }
    public void SaveChanges()
    {

    }
    public void ResetChanges()
    {

    }
    //Possibly replace with method call
    public void EnableTips()
    {
        TipsControl.TipsEnabled = !TipsControl.TipsEnabled;
    }
}
