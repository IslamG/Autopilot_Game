using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListKeyPair : ScriptableObject
{
    TMP_Text text;
    TMP_InputField input;
    string keyName;
    KeyCode keyCode;

    public TMP_Text Text { get => text; set => text = value; }
    public TMP_InputField Input { get => input; set => input = value; }
    public string KeyName { get => keyName; set => keyName = value; }
    public KeyCode KeyCode { get => keyCode; set => keyCode = value; }

}
