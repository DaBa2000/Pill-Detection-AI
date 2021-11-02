using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    // pill taht should be detected
    private static int detect_pill = 0;
    // agora id connection client and caregiver
    private static string agora_id;
    // coordinates for placement indicator
    public static float marker_y = 0;
    public static float marker_x = 0;
    // coordinates for arrow
    public static float arrow_y = 0;
    public static float arrow_x = 0;
    // text size of apps
    public static float textSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        // find all instances of text
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        // for each text, scale the text to the selected size
        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                cmp.fontSize = cmp.fontSize * textSize;
            }
        }

        GameController.SetAgoraID(PlayerPrefs.GetString("agoraID"));
    }

    /// <summary>
    /// Opens a new scene
    /// </summary>
    /// <param name="scene_name">next scene</param>
    public static void OpenScene(string scene_name)
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(scene_name);
    }

    /// <summary>
    /// set pill to be detected
    /// </summary>
    /// <param name="pill">id of pill to be detected</param>
    public static void SetDetectedPill(int pill)
    {
        detect_pill = pill;
        OpenScene("KI");
    }

    /// <summary>
    /// Quit KI scene in between two detections
    /// </summary>
    /// <param name="nextScene">next scene to be opened</param>
    public static void ReturnFromKI(string nextScene)
    {
        FindObjectOfType<ImageDetection>().quitScene(nextScene);
    }

    public static int GetDetectedPill()
    {
        return detect_pill;
    }

    public static void SetAgoraID(string id)
    {
        agora_id = id;
    }

    public static string GetAgoraID()
    {
        return agora_id;
    }

    public static void startTutorialAgain()
    {
        PlayerPrefs.SetInt("tutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
