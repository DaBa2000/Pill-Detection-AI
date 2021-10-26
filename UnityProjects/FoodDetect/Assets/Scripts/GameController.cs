using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static float textSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                cmp.fontSize = cmp.fontSize * textSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void OpenScene(string scene_name)
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(scene_name);
    }

    public static void startTutorialAgain()
    {
        PlayerPrefs.SetInt("tutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
