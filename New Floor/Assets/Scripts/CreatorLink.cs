using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatorLink : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI text;
    Camera cam;

    protected virtual void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        cam = Camera.main;
    }
    void Start()
    {
        CheckLinks();
    }
    void LateUpdate()
    {
        // is the cursor in the correct region (above the text area) and furthermore, in the link region?
        var isHoveringOver = TMP_TextUtilities.IsIntersectingRectTransform(text.rectTransform, Input.mousePosition, cam);
    }
    // Check links in text 
    void CheckLinks()
    {
        Regex regx = new Regex("((http://|https://|www\\.)([A-Z0-9.-:]{1,})\\.[0-9A-Z?;~&#=\\-_\\./]{2,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        MatchCollection matches = regx.Matches(text.text);
        foreach (Match match in matches)
            text.text = text.text.Replace(match.Value, ShortLink(match.Value));
    }
    // Cut long url 
    string ShortLink(string link)
    {
        string text = link;
        int left = 9;
        int right = 16;
        string cut = "...";
        if (link.Length > (left + right + cut.Length))
            text = string.Format("{0}{1}{2}", link.Substring(0, left), cut, link.Substring(link.Length - right, right));
        return string.Format("<#7f7fe5><u><link=\"{0}\">{1}</link></u></color>", link, text);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, eventData.pressEventCamera);
        if (linkIndex == -1)
            return;
        TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
        string selectedLink = linkInfo.GetLinkID();
        if (selectedLink != "")
        {
            Debug.LogFormat("Open link {0}", selectedLink);
            Application.OpenURL(selectedLink);
        }
        Debug.Log("Reacting");
    }
}

