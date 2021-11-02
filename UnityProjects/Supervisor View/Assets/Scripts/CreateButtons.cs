using UnityEngine;
using TMPro;
public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Get number of connected users
        int num_users = PlayerPrefs.GetInt("num_users");

        for (int i = 0; i < num_users; i++)
        {
            // for each user create new button
            GameObject canvas =  GameObject.Find("Canvas");
            GameObject go = Instantiate(buttonPrefab);
            go.transform.SetParent(canvas.transform);
            go.transform.position = new Vector3(0.5f * Screen.width, Screen.height - (i+0.5f)*0.1f*Screen.height, 0);
            go.transform.localScale = new Vector3(1, 1, 1);

            // set button text
            var button = go.GetComponent<UnityEngine.UI.Button>();
            go.transform.Find("Name").transform.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("username" + (i + 1));
            go.transform.Find("Id").transform.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("userid" + (i + 1));
        }
    }
}


