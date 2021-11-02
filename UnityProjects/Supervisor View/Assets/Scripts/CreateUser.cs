using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateUser : MonoBehaviour
{
    public GameObject id_panel;
    public TMP_InputField name_input;

    private int num_users;
    private string userID;

    // Start is called before the first frame update
    void Start()
    {
        // create random user id
        userID = "" + (int) Random.Range(0, 9999);
        // show userid on screen
        id_panel.GetComponent<TextMeshProUGUI>().SetText("ID: " + userID);

        num_users = PlayerPrefs.GetInt("num_users");
    }

    /// <summary>
    /// Add user to streaming
    /// </summary>
    public void addUser()
    {
        // set new number of users
        num_users++;
        PlayerPrefs.SetInt("num_users", num_users);

        // save new user
        PlayerPrefs.SetString("userid" + num_users, userID);
        PlayerPrefs.SetString("username" + num_users, name_input.text);
    }
}
