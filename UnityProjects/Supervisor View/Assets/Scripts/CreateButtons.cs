using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int num_users = PlayerPrefs.GetInt("num_users");
        //Debug.Log(num_users);

        for (int i = 0; i < num_users; i++)
        {
            //Debug.Log(PlayerPrefs.GetString("username" + (i + 1)));
            //Debug.Log(PlayerPrefs.GetString("userid" + (i + 1)));

            GameObject canvas =  GameObject.Find("Canvas");
            
            GameObject go = Instantiate(buttonPrefab);
            go.transform.SetParent(canvas.transform);
            go.transform.position = new Vector3(0.5f * Screen.width, Screen.height - (i+0.5f)*0.1f*Screen.height, 0);
            go.transform.localScale = new Vector3(1, 1, 1);

            var button = go.GetComponent<UnityEngine.UI.Button>();

            go.transform.Find("Name").transform.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("username" + (i + 1));
            go.transform.Find("Id").transform.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("userid" + (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


