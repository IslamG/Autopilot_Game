using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private string messageHeader, messageBody;
    [SerializeField]
    private bool includeCancel, includeField, isImage;
    [SerializeField]
    private PopUpGen popUpGen;
    [SerializeField]
    private Sprite displayImage;

    public string MessageHeader { get => messageHeader; set => messageHeader = value; }
    public string MessageBody { get => messageBody; set => messageBody = value; }
    public bool IncludeCancel { get => includeCancel; set => includeCancel = value; }
    public bool IncludeField { get => includeField; set => includeField = value; }
    public bool IsImage { get => isImage; set => isImage = value; }
    public Sprite DisplayImage { get => displayImage; set => displayImage = value; }

    //Call handler for generating a popUp with information in class
    public void ShowPop()
    {
        popUpGen.GeneratePopUp(this);
    }
}
