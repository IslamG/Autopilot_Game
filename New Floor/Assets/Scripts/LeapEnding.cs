using UnityEngine;
using UnityEngine.Video;

public class LeapEnding : MonoBehaviour
{
    [SerializeField]
    GameObject credits;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Play ending");
            credits.SetActive(true);
            credits.GetComponent<VideoPlayer>().Play();

        }
    }
}
