using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class PlacePlane : MonoBehaviour
{
    // RayCast Manager to place Informational Plane in Scene
    public ARRaycastManager rcManager;
    public GameObject plane_prefab;

    // Materials from Nutro-Score 1 - 5
    public Material nutri_a;
    public Material nutri_b;
    public Material nutri_c;
    public Material nutri_d;
    public Material nutri_e;

    /// <summary>
    /// PLace info plane in AR scnene
    /// </summary>
    /// <param name="detection">object with grocery preferences</param>
    public void placePlane(BarcodeAPIResult detection)
    {
        // load prefab plane
        GameObject plane = Instantiate(plane_prefab);

        // configure plane based on info
        setPlaneText(plane, detection);

        // send raycast into scene
        Vector3 raycastOrigin = new Vector3(0.5f, 0.5f, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);

        // place informational plane in scene
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose p = hits[0].pose;
            plane.transform.SetPositionAndRotation(p.position, p.rotation);
            plane.transform.LookAt(Camera.current.transform);
        }
    }

    /// <summary>
    /// Set text of informational plane
    /// </summary>
    /// <param name="plane">Plane to set text</param>
    /// <param name="detection">Object with information about product</param>
    public void setPlaneText(GameObject plane, BarcodeAPIResult detection)
    {
        // Possible attributes
        bool isRecommended = true;
        string recommendation = "";

        string name;
        if (detection.product.product_name_en != null) name = detection.product.product_name_en;
        else name = detection.product.product_name;
        plane.transform.Find("Cube").Find("placeholder_name").GetComponent<TextMeshPro>().text = name;

        bool vegetarian = true;
        bool vegan = true;
        string comment = "";

        // Handle missing information
        if (detection.product.ingredients == null)
        {
            plane.transform.Find("Cube").Find("placeholder_classification").GetComponent<TextMeshPro>().text = "Product Status Unknown";
            plane.transform.Find("Cube").Find("placeholder_classification_ing").GetComponent<TextMeshPro>().text = "";
        } else
        // If information is available set text on plane
        {
            /*
             * Chech if product is vegetarian or vegan
             */

            // check all ingredients if they are vegan or vegetarian
            foreach (Ingrediant s in detection.product.ingredients)
            {
                if (s.vegetarian != null && s.vegetarian.Equals("no"))
                {
                    vegetarian = false;
                    vegan = false;
                    comment += "Product contains " + s.text + " which is not vegetarian.\n";
                }
                else if (s.vegan != null && s.vegan.Equals("no"))
                {
                    vegan = false;
                    comment += "Product contains " + s.text + " which is not vegan.\n";
                }
            }

            // check all ingrediants informations if they are vegetarian or vegan
            foreach (string i in detection.product.ingredients_analysis_tags)
            {
                if (i.Replace("en:", "").Contains("vegan-status-unknown") || i.Replace("en:", "").Contains("non-vegan"))
                {
                    vegan = false;
                }

                if (i.Replace("en:", "").Contains("vegetarian-status-unknown") || i.Replace("en:", "").Contains("non-vegetarian"))
                {
                    vegetarian = false;
                    vegan = false;
                }
            }

            // Set text if product is vegetarian or vegan
            if (vegan)
            {
                plane.transform.Find("Cube").Find("placeholder_classification").GetComponent<TextMeshPro>().text = "Product is vegan";
            }
            else if (vegetarian)
            {
                plane.transform.Find("Cube").Find("placeholder_classification").GetComponent<TextMeshPro>().text = "Product is vegetarian";

                if (PlayerPrefs.GetInt("vegan") == 1)
                {
                    isRecommended = false;
                    recommendation += "Product is not vegan\n";
                }
            }
            else
            {
                plane.transform.Find("Cube").Find("placeholder_classification").GetComponent<TextMeshPro>().text = "Product not vegetarian";

                if (PlayerPrefs.GetInt("vegan") == 1)
                {
                    isRecommended = false;
                    recommendation += "Product is not vegan\n";
                } else if (PlayerPrefs.GetInt("vegetarian") == 1)
                {
                    isRecommended = false;
                    recommendation += "Product is not vegetarian\n";
                }
            }

            plane.transform.Find("Cube").Find("placeholder_classification_ing").GetComponent<TextMeshPro>().text = comment;
        }

        /*
         *  Set nutrisore image
         */
        switch(detection.product.nutriscore_grade)
        {
            case "a":
                plane.transform.Find("Cube").Find("Plane").GetComponent<MeshRenderer>().material = nutri_a;
                break;
            case "b":
                plane.transform.Find("Cube").Find("Plane").GetComponent<MeshRenderer>().material = nutri_b;
                break;
            case "c":
                plane.transform.Find("Cube").Find("Plane").GetComponent<MeshRenderer>().material = nutri_c;
                break;
            case "d":
                plane.transform.Find("Cube").Find("Plane").GetComponent<MeshRenderer>().material = nutri_d;
                recommendation += "Product has low nutriscore\n";
                break;
            case "e":
                plane.transform.Find("Cube").Find("Plane").GetComponent<MeshRenderer>().material = nutri_e;
                recommendation += "Product has low nutriscore\n";
                break;
        }


        /*
         * Set allergenes
         */
        string[] allergenes = detection.product.allergens_tags;
        string all_text = "";

        // check all allergenes
        foreach (string s in allergenes)
        {
            all_text += s.Replace("en:", "") + " ";
            if (s.Replace("en:", "").Contains("gluten") && PlayerPrefs.GetInt("allergic_wheat") == 1) {
                isRecommended = false;
                recommendation += "Product in conflict with wheat allergy\n";
            }

            if (s.Replace("en:", "").Contains("milk") && PlayerPrefs.GetInt("allergic_milk") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with lactose allergy\n";
            }

            if (s.Replace("en:", "").Contains("peanuts") && PlayerPrefs.GetInt("allergic_peanuts") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with peanut allergy\n";
            }

            if (s.Replace("en:", "").Contains("soy") && PlayerPrefs.GetInt("allergic_soys") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with soy allergy\n";
            }

            if (s.Replace("en:", "").Contains("nut") && PlayerPrefs.GetInt("allergic_treenuts") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with tree-nut allergy\n";
            }

            if (s.Replace("en:", "").Contains("fish") && PlayerPrefs.GetInt("allergic_fish") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with fish allergy\n";
            }
        }

        // check all ingredients
        string[] ingredients = detection.product.ingredients_analysis_tags;
        
        foreach (string i in ingredients)
        {

            if (i.Replace("en:", "").Contains("egg") && PlayerPrefs.GetInt("allergic_eggs") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with egg allergy\n";
            }

            if (i.Replace("en:", "").Contains("seafood") && PlayerPrefs.GetInt("allergic_shellfish") == 1)
            {
                isRecommended = false;
                recommendation += "Product in conflict with shellfish allergy\n";
            }

        }

        plane.transform.Find("Cube").Find("placeholder_allergenes").GetComponent<TextMeshPro>().text = all_text;

        /*
         * Set recommendations
         */
        if (isRecommended)
        {
            recommendation += "No nutrition conflicts";
            plane.transform.Find("Cube").Find("placeholder_recommendation").GetComponent<TextMeshPro>().text = recommendation;
            plane.transform.Find("Cube").Find("placeholder_recommendation").GetComponent<TextMeshPro>().color = new Color(0, 153, 0);
        } else
        {
            plane.transform.Find("Cube").Find("placeholder_recommendation").GetComponent<TextMeshPro>().text = recommendation;
            plane.transform.Find("Cube").Find("placeholder_recommendation").GetComponent<TextMeshPro>().color = Color.red;
        }
    }
}
