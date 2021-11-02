using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    // Agora streaming ID 
    private static string agora_id;

    /// <summary>
    /// Open scene by name
    /// </summary>
    /// <param name="name">name of scene</param>
    public static void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void SetAgoraID(string id)
    {
        agora_id = id;
    }

    public static string GetAgoraID()
    {
        return agora_id;
    }

    // select which agora id to connect to via buttons
    public static void SetID(Button button)
    {
        Button[] objects = GameObject.FindObjectsOfType<Button>();

        Color c;
        ColorUtility.TryParseHtmlString("#00F8FF", out c);

        foreach (Button b in objects)
        {
            b.GetComponent<Image>().color = c;
        }

        GameController.agora_id = button.transform.Find("Id").transform.gameObject.GetComponent<TextMeshProUGUI>().text;
        button.GetComponent<Image>().color = Color.blue;
    }
}
