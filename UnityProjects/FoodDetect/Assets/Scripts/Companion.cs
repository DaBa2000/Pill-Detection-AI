using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class Companion : MonoBehaviour
{
    // animate 2d companion blinking
    public Animator animator;
    // Play sounds when clicking companion
    public SoundManagement sm;

    // Start is called before the first frame update
    void Start()
    {
        // if no AR scene is open, start 2D animation
        if (SceneManager.GetActiveScene().name != "ScanProducts")
        {
            StartCoroutine(Blink());
        }
        else
        // if AR scnene is open, start companion replacement every 30s
        {
            StartCoroutine(ReplaceCompanion());
        }

        sm = FindObjectOfType<SoundManagement>();

        // if tutorial has not been played, start tutorial
        if (PlayerPrefs.GetInt("tutorial") == 0)
        {
            StartCoroutine(StartTutorial());
        }
    }

    /// <summary>
    /// Replace Companion every 30 seconds, so that it doesnt get lost when moving phone
    /// </summary>
    private IEnumerator ReplaceCompanion()
    {
        yield return new WaitForSeconds(3);
        PlaceCompanion();

        while (true)
        {
            yield return new WaitForSeconds(30);
            PlaceCompanion();
        }
    }

    /// <summary>
    /// Start blinking animation in random intervals
    /// </summary>
    private IEnumerator Blink()
    {
        while (true)
        {
            animator.SetTrigger("comp_blink");
            yield return new WaitForSecondsRealtime(Random.Range(1, 7));
        }
    }

    /// <summary>
    /// Control Tutorial
    /// </summary>
    IEnumerator StartTutorial()
    {
        // Check which scene is opened and start fitting part of tutorial
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

            text_tutorial.text = "Welcome to FoodTrack AR";
            sm.PlaySound("Tutorial_1");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "I am Blu, your personal companion for this application";
            sm.PlaySound("Tutorial_2");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "If you ever need help or feel lost, you can click me for guidance.";
            sm.PlaySound("Tutorial_3");
            yield return new WaitForSeconds(4);

            yield return StartCoroutine(TutorialMainMenu());

            GameController.OpenScene("FoodSettings");
        }
        else if (SceneManager.GetActiveScene().name == "FoodSettings")
        {
            yield return StartCoroutine(TutorialSelectPref());
            GameController.OpenScene("ScanProducts");
        }
        else if (SceneManager.GetActiveScene().name == "Settings")
        {
            yield return StartCoroutine(TutorialSettings());

            TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

            text_tutorial.text = "Thank you for following my Tutorial";
            sm.PlaySound("Tutorial_4");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "If you need help again you know where to find me.";
            sm.PlaySound("Tutorial_5");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "Now enjoy using the App. Goodbye.";
            sm.PlaySound("Tutorial_6");
            yield return new WaitForSeconds(5);

            PlayerPrefs.SetInt("tutorial", 1);
        }
        else if (SceneManager.GetActiveScene().name == "ScanProducts")
        {
            yield return StartCoroutine(TutorialAR());
            GameController.OpenScene("Settings");
        }
    }

    /// <summary>
    /// Detect click on companion and start scene explaination
    /// </summary>
    void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name != "ScanProducts")
        {
            animator.SetTrigger("comp_click");
        }

        StartSceneExplaination();
    }

    /// <summary>
    /// Decide which explaination to start based on scene
    /// </summary>
    void StartSceneExplaination()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            StartCoroutine(TutorialMainMenu());
        }
        else if (SceneManager.GetActiveScene().name == "FoodSettings")
        {
            StartCoroutine(TutorialSelectPref());
        }
        else if (SceneManager.GetActiveScene().name == "Settings")
        {
            StartCoroutine(TutorialSettings());
        }
        else if (SceneManager.GetActiveScene().name == "ScanProducts")
        {
            StartCoroutine(TutorialAR());
        }
    }

    /// <summary>
    /// Tutorial for settings page
    /// </summary>
    IEnumerator TutorialSettings()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");
        GameObject button_Restart = GameObject.Find("Restart");
        GameObject button_FoodSettings = GameObject.Find("FoodSettings");

        GameObject input_size = GameObject.Find("sizeInput").transform.Find("Background").gameObject;

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string settings_scene1 = "This page is for your personal Settings.";
        string settings_scene2 = "If you want to change your text size, use the handler";
        string settings_scene2_1 = "Drag it to the left for smaller text and to the right for larger text";
        string settings_scene3 = "If you want to change your food preferences, click on the Button: Food Settings";
        string settings_scene4 = "If you want to return to the main menu, click: Main Menu";
        string settings_scene5 = "If you want to go back, click: Back";
        string settings_scene6 = "If you want to restart the whole tutorial, click: Restart Tutorial";


        text_tutorial.text = settings_scene1;
        sm.PlaySound("Settings_1");
        yield return new WaitForSeconds(4);

        text_tutorial.text = settings_scene2;
        sm.PlaySound("Settings_2");
        yield return new WaitForSeconds(4);
        StartCoroutine(HighlightComponent(input_size));
        text_tutorial.text = settings_scene2_1;
        yield return new WaitForSeconds(5);

        text_tutorial.text = settings_scene3;
        sm.PlaySound("Settings_3");
        yield return new WaitForSeconds(3);
        StartCoroutine(HighlightComponent(button_FoodSettings));
        yield return new WaitForSeconds(3);

        text_tutorial.text = settings_scene4;
        sm.PlaySound("Settings_4");
        yield return new WaitForSeconds(4);
        StartCoroutine(HighlightComponent(button_MainMenu));
        yield return new WaitForSeconds(2);

        text_tutorial.text = settings_scene5;
        sm.PlaySound("Settings_5");
        yield return new WaitForSeconds(4);
        StartCoroutine(HighlightComponent(button_Back));
        yield return new WaitForSeconds(2);

        text_tutorial.text = settings_scene6;
        sm.PlaySound("Settings_6");
        yield return new WaitForSeconds(4);
        StartCoroutine(HighlightComponent(button_Restart));
        yield return new WaitForSeconds(2);
    }

    /// <summary>
    /// Tutorial for select food preferences page
    /// </summary>
    IEnumerator TutorialSelectPref()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");
        
        GameObject text_panel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        text_panel.SetActive(true);

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string pill_scene1 = "You are now seeing your personal food preferences.";
        string pill_scene2 = "To select a preference or state an allergy click on the checkbox next to it.";
        string pill_scene3 = "If you want to return to the previous page, click: Back";
        string pill_scene4 = "If you want to return to the Main Menu press: Main Menu";

        text_tutorial.text = pill_scene1;
        sm.PlaySound("FoodSettings_1");
        yield return new WaitForSeconds(4);

        text_tutorial.text = pill_scene2;
        sm.PlaySound("FoodSettings_2");
        yield return new WaitForSeconds(5);

        text_tutorial.text = pill_scene3;
        sm.PlaySound("FoodSettings_3");
        yield return new WaitForSeconds(3);
        StartCoroutine(HighlightComponent(button_Back));
        yield return new WaitForSeconds(2);

        text_tutorial.text = pill_scene4;
        sm.PlaySound("FoodSettings_4");
        yield return new WaitForSeconds(3);
        StartCoroutine(HighlightComponent(button_MainMenu));
        yield return new WaitForSeconds(3);
    }

    /// <summary>
    /// Tutorial for barcode scanner page
    /// </summary>
    IEnumerator TutorialAR()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");

        GameObject text_panel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        text_panel.SetActive(true);

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string pill_scene1 = "In this scene you can get grocery information by scanning groceries barcodes.";
        string pill_scene2 = "Therefore place the barcode in front of your devices camera and the information will appear.";
        string pill_scene3 = "If you want to go back, click: Back";
        string pill_scene4 = "If you want to return to the Main Menu press: Main Menu";

        text_tutorial.text = pill_scene1;
        sm.PlaySound("Grocery_1");
        yield return new WaitForSeconds(5);

        text_tutorial.text = pill_scene2;
        sm.PlaySound("Grocery_2");
        yield return new WaitForSeconds(6);

        text_tutorial.text = pill_scene3;
        sm.PlaySound("Grocery_3");
        yield return new WaitForSeconds(3);
        StartCoroutine(HighlightComponent(button_Back));
        yield return new WaitForSeconds(2);

        text_tutorial.text = pill_scene4;
        sm.PlaySound("Grocery_4");
        yield return new WaitForSeconds(3);
        StartCoroutine(HighlightComponent(button_MainMenu));
        yield return new WaitForSeconds(3);

        text_panel.SetActive(false);
    }

    /// <summary>
    /// Tutorial for main menu
    /// </summary>
    IEnumerator TutorialMainMenu()
    {
        GameObject button_start = GameObject.Find("Start");
        GameObject button_settings = GameObject.Find("Settings");
        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>(); ;

        string main_scene1 = "You are currently seeing our main menu.";
        string main_scene2 = "If you want to scan the barcode of a new product click: Scan Product";
        string main_scene3 = "If you want to customize the application or change your personal settings, click: Settings";

        text_tutorial.text = main_scene1;
        sm.PlaySound("MainMenu_1");
        yield return new WaitForSeconds(4);

        text_tutorial.text = main_scene2;
        sm.PlaySound("MainMenu_2");
        yield return new WaitForSeconds(5);
        StartCoroutine(HighlightComponent(button_start));
        yield return new WaitForSeconds(2);

        text_tutorial.text = main_scene3;
        sm.PlaySound("MainMenu_3");
        yield return new WaitForSeconds(5);
        StartCoroutine(HighlightComponent(button_settings));
        yield return new WaitForSeconds(3);
    }


    /// <summary>
    /// Highlight component
    /// </summary>
    /// <param name="obj">object to be highlighted</param>
    private IEnumerator HighlightComponent(GameObject obj)
    {
        // change color to red
        Color oldColor = obj.GetComponent<Image>().color;
        obj.GetComponent<Image>().color = Color.red;

        // let object slowly increase in size
        for (int i = 0; i < 10; i++)
        {
            obj.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.1f, 1.1f, 1.1f), i / 10.0f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.1f);

        // let object slowly decrease in size
        for (int i = 10; i > 0; i--)
        {
            obj.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.1f, 1.1f, 1.1f), i / 10.0f);
            yield return new WaitForSeconds(0.01f);
        }

        // reset old color ob component
        obj.GetComponent<Image>().color = oldColor;
    }

    /// <summary>
    /// Place component in the scene
    /// </summary>
    private void PlaceCompanion()
    {
        // cast ray into the scene
        Vector3 raycastOrigin = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager rcManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        rcManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        // place companion at first hit
        if (hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            GameObject.Find("Companion").transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
    }
}
