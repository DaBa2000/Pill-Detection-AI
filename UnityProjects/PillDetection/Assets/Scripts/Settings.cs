using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public TMP_InputField IdInputField;

    // Start is called before the first frame update
    void Start()
    {
        loadID();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetTextSize(float size)
    {
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                cmp.fontSize = cmp.fontSize / GameController.textSize * size;
            }
        }

        GameController.textSize = size;
    }

    public void setID(string ID)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            Debug.Log(scene.name);
            if (scene.name == "AR")
            {
                SceneManager.UnloadSceneAsync("AR");
            }
        }

        
        PlayerPrefs.SetString("agoraID", ID);
        GameController.SetAgoraID(ID);
    }

    public void loadID()
    {
        IdInputField.text = PlayerPrefs.GetString("agoraID");
    }
}
