using UnityEngine;
using UnityEngine.SceneManagement;

//GameObject that persists throughout all levels and controls 
//the loading between levels
//it mediates between levels and the loading screen
public class LevelTraversal : MonoBehaviour
{
    [SerializeField]
    private static string sourceLevel, targetLevel;
    private static bool created = false;
    //Properties to pass data between scenes
    public static string SourceLevel { get => sourceLevel; set => sourceLevel = value; }
    public static string TargetLevel { get => targetLevel; set => targetLevel = value; }

    //Singleton class
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //Once loaded get the name of the scene its in
    private void Start()
    {
        sourceLevel = SceneManager.GetActiveScene().name;
    }
    public void Load()
    {
        SceneManager.LoadScene(TargetLevel);
    }
}
