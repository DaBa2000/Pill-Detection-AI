using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private static int detect_pill = 0;
    private static string agora_id;

    public static float marker_y = 0;
    public static float marker_x = 0;

    public static float arrow_y = 0;
    public static float arrow_x = 0;

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

        GameController.SetAgoraID(PlayerPrefs.GetString("agoraID"));
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

    public static void SetDetectedPill(int pill)
    {
        detect_pill = pill;
        OpenScene("KI");
    }

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
