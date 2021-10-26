using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFoodPreferences()
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
