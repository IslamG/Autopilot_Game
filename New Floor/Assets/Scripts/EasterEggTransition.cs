using UnityEngine;

public class EasterEggTransition : MonoBehaviour
{
    [SerializeField]
    Material newSky;
    [SerializeField]
    GameObject returnSign, markerSign;

    bool isFound = false;
    Material oldSky;

    void Start()
    {
        oldSky = RenderSettings.skybox;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFound)
        {
            RenderSettings.skybox = newSky;
            isFound = true;
            markerSign.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (gameObject.name.Equals(returnSign.name))
        {
            RenderSettings.skybox = oldSky;
            reSpawn();
        }
    }
    public void reSpawn()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.transform.position = markerSign.transform.position;
    }
}
