using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindings : MonoBehaviour
{
    [SerializeField]
    private string[] wordList;
    //[SerializeField]
    //VerticalLayoutGroup place;
    //Text text;
    //[SerializeField]
    //Text text;
    //[SerializeField]
    //InputField input;
    //[SerializeField]
    //ListKeyPair keyObj;
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
    public void EnableTips()
    {

    }
}
