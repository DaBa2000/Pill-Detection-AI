using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class PlacePane : MonoBehaviour
{
    public ARRaycastManager rcManager;
    public GameObject plane_prefab;

    public Material nutri_a;
    public Material nutri_b;
    public Material nutri_c;
    public Material nutri_d;
    public Material nutri_e;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void placePane(BarcodeAPIResult detection)
    {
        GameObject plane = Instantiate(plane_prefab);

        setPlaneText(plane, detection);

        Vector3 raycastOrigin = new Vector3(0.5f, 0.5f, 0);
        raycastOrigin = Camera.current.ViewportToScreenPoint(raycastOrigin);

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose p = hits[0].pose;
            plane.transform.SetPositionAndRotation(p.position, p.rotation);

            plane.transform.LookAt(Camera.current.transform);
        }
    }

    public void setPlaneText(GameObject plane, BarcodeAPIResult detection)
    {
        bool isRecommended = true;
        string recommendation = "";

        string name;
        if (detection.product.product_name_en != null) name = detection.product.product_name_en;
        else name = detection.product.product_name;
        plane.transform.Find("Cube").Find("placeholder_name").GetComponent<TextMeshPro>().text = name;

        bool vegetarian = true;
        bool vegan = true;
        string comment = "";

        if (detection.product.ingredients == null)
        {
            plane.transform.Find("Cube").Find("placeholder_classification").GetComponent<TextMeshPro>().text = "Product Status Unknown";
            plane.transform.Find("Cube").Find("placeholder_classification_ing").GetComponent<TextMeshPro>().text = "";
        } else {
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

        string[] allergenes = detection.product.allergens_tags;
        string all_text = "";

        foreach (string s in allergenes)
        {
            all_text += s.Replace("en:", "") + " ";
            if (s.Replace("en:", "").Contains("gluten")) {
                isRecommended = false;
                recommendation += "Product in conflict with wheat allergy\n";
            }
        }

        plane.transform.Find("Cube").Find("placeholder_allergenes").GetComponent<TextMeshPro>().text = all_text;


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
