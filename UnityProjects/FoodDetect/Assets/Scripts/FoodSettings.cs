using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSettings : MonoBehaviour
{
    bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadFoodPreferences();
        loaded = true;
    }

    /// <summary>
    /// Set Playerprefs based on selected food preferences
    /// </summary>
    public void SetFoodPreferences()
    {
        if (loaded)
        {
            if (GameObject.Find("Vegetarian").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("vegetarian", 1);
            else PlayerPrefs.SetInt("vegetarian", 0);

            if (GameObject.Find("Vegan").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("vegan", 1);
            else PlayerPrefs.SetInt("vegan", 0);

            if (GameObject.Find("Milk").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_milk", 1);
            else PlayerPrefs.SetInt("allergic_milk", 0);

            if (GameObject.Find("Eggs").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_eggs", 1);
            else PlayerPrefs.SetInt("allergic_eggs", 0);

            if (GameObject.Find("Peanuts").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_peanuts", 1);
            else PlayerPrefs.SetInt("allergic_peanuts", 0);

            if (GameObject.Find("Soy").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_soy", 1);
            else PlayerPrefs.SetInt("allergic_soy", 0);

            if (GameObject.Find("Wheat").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_wheat", 1);
            else PlayerPrefs.SetInt("allergic_wheat", 0);

            if (GameObject.Find("TreeNuts").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_treenuts", 1);
            else PlayerPrefs.SetInt("allergic_treenuts", 0);

            if (GameObject.Find("Fish").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_fish", 1);
            else PlayerPrefs.SetInt("allergic_fish", 0);

            if (GameObject.Find("Shellfish").GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("allergic_shellfish", 1);
            else PlayerPrefs.SetInt("allergic_shellfish", 0);
        }
    }

    /// <summary>
    /// Load food preferences from playerprefs
    /// </summary>
    public void LoadFoodPreferences()
    {
        if (PlayerPrefs.GetInt("vegetarian") == 1) GameObject.Find("Vegetarian").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Vegetarian").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("vegan") == 1) GameObject.Find("Vegan").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Vegan").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_milk") == 1) GameObject.Find("Milk").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Milk").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_eggs") == 1) GameObject.Find("Eggs").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Eggs").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_peanuts") == 1) GameObject.Find("Peanuts").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Peanuts").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_soy") == 1) GameObject.Find("Soy").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Soy").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_wheat") == 1) GameObject.Find("Wheat").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Wheat").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_treenuts") == 1) GameObject.Find("TreeNuts").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("TreeNuts").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_fish") == 1) GameObject.Find("Fish").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Fish").GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("allergic_shellfish") == 1) GameObject.Find("Shellfish").GetComponent<Toggle>().isOn = true;
        else GameObject.Find("Shellfish").GetComponent<Toggle>().isOn = false;
    }
}
