using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    // current font size
    public static float textSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        // change font sitze
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                cmp.fontSize = cmp.fontSize * textSize;
            }
        }
    }

    /// <summary>
    /// Open new scene
    /// </summary>
    /// <param name="scene_name">scene to be opened</param>
    public static void OpenScene(string scene_name)
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(scene_name);
    }

    /// <summary>
    /// Restart Turoorial
    /// </summary>
    public static void startTutorialAgain()
    {
        PlayerPrefs.SetInt("tutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
