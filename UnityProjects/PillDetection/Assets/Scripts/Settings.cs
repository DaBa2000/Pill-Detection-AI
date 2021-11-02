using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    // Input field for AgoraID
    public TMP_InputField IdInputField;

    // Start is called before the first frame update
    void Start()
    {
        // get AgoraID from playerprefs
        loadID();
    }

    /// <summary>
    /// Set the scenes text size
    /// </summary>
    /// <param name="size">size of text</param>
    public static void SetTextSize(float size)
    {
        // find all instances of text
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        // for each text, scale the text to the selected size
        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                // in order to scale correctily, text size is first rescaled to normal by dividing through old size, and then multiplyed by new size
                cmp.fontSize = cmp.fontSize / GameController.textSize * size;
            }
        }

        // set current text size
        GameController.textSize = size;
    }

    /// <summary>
    /// Set the Apps AgoraID
    /// </summary>
    /// <param name="ID">AgoraOD that should be set</param>
    public void setID(string ID)
    {
        // Unload AR scene, as scene hast to be restarted in order to make ID-Change possible
        // old scene would use old AgoraID
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == "AR")
            {
                SceneManager.UnloadSceneAsync("AR");
            }
        }

        // set playerpref
        PlayerPrefs.SetString("agoraID", ID);
        // reset current id
        GameController.SetAgoraID(ID);
    }

    /// <summary>
    /// get current AgoraID
    /// </summary>
    public void loadID()
    {
        IdInputField.text = PlayerPrefs.GetString("agoraID");
    }
}
