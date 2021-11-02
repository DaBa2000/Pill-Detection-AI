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
        // if  no AR scene is open, start 2D animation
        if (SceneManager.GetActiveScene().name != "KI" && SceneManager.GetActiveScene().name != "AR")
        {
            StartCoroutine(Blink());
        } else
        // if AR scnene is open, start companion replacement every 30s
        {
            StartCoroutine(ReplaceCompanion());
        }

        sm = FindObjectOfType<SoundManagement>();

        // if tutorial has not been played, start tutorial
        if (PlayerPrefs.GetInt("tutorial") == 0)
        {
            StartCoroutine(startTutorial());
        }
    }

    /// <summary>
    /// Replace Companion every 30 seconds, so that it doesnt get lost when moving phone
    /// </summary>
    private IEnumerator ReplaceCompanion()
    {
        yield return new WaitForSeconds(3);
        placeCompanion();

        while (true)
        {
            yield return new WaitForSeconds(30);
            placeCompanion();
        }
    }

    /// <summary>
    /// Start blinking animation in random intervals
    /// </summary>
    /// <returns></returns>
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
    IEnumerator startTutorial()
    {
        // Check which scene is opened and start fitting part of tutorial
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

            text_tutorial.text = "Welcome to AR Pill";
            sm.PlaySound("Tutorial1");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "I am Blu, your personal companion for this application";
            sm.PlaySound("Tutorial2");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "If you need help or feel lost, click me for guidance.";
            sm.PlaySound("Tutorial3");
            yield return new WaitForSeconds(4);

            yield return StartCoroutine(TutorialMainMenu());

            GameController.OpenScene("SelectPill");
        }
        else if (SceneManager.GetActiveScene().name == "SelectPill")
        {
            yield return StartCoroutine(TutorialSelectPill());
            GameController.OpenScene("KI");
        }
        else if (SceneManager.GetActiveScene().name == "KI")
        {
            yield return StartCoroutine(TutorialKI());
            GameController.OpenScene("AR");
        }
        else if (SceneManager.GetActiveScene().name == "AR")
        {
            yield return StartCoroutine(TutorialAR());
            GameController.OpenScene("Settings");
        }
        else if (SceneManager.GetActiveScene().name == "Settings")
        {
            yield return StartCoroutine(TutorialSettings());

            TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

            text_tutorial.text = "Thank you for following my Tutorial";
            sm.PlaySound("Tutorial4");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "If you need help again you know where to find me.";
            sm.PlaySound("Tutorial5");
            yield return new WaitForSeconds(4);

            text_tutorial.text = "Now enjoy using the App. Goodbye.";
            sm.PlaySound("Tutorial6");
            yield return new WaitForSeconds(5);

            PlayerPrefs.SetInt("tutorial", 1);
        }
    }

    /// <summary>
    /// Detect click on companion and start scene explaination
    /// </summary>
    void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name != "KI" && SceneManager.GetActiveScene().name != "AR")
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
        else if (SceneManager.GetActiveScene().name == "SelectPill")
        {
            StartCoroutine(TutorialSelectPill());
        }
        else if (SceneManager.GetActiveScene().name == "KI")
        {
            StartCoroutine(TutorialKI());
        }
        else if (SceneManager.GetActiveScene().name == "AR")
        {
            StartCoroutine(TutorialAR());
        }
        else if (SceneManager.GetActiveScene().name == "Settings")
        {
            StartCoroutine(TutorialSettings());
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

        GameObject text_id = GameObject.Find("idText");
        GameObject text_size = GameObject.Find("sizeText");

        GameObject input_id = GameObject.Find("idInput");
        GameObject input_size = GameObject.Find("sizeInput").transform.Find("Background").gameObject;

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string settings_scene1 = "This page is for your personal Settings.";
        string settings_scene2 = "To connect to a caregiver, who can help you identify pills by looking though your camera...";
        string settings_scene3 = "... you can enter an ID, given to you by your supervisor.";
        string settings_scene4 = "To increase or decrease the applications text size, slide the circle to the left or right";
        string settings_scene5 = "Slide to the left for smaller Text or to the right for larger text.";
        string settings_scene6 = "If you want to return to the previous page, press: Back";
        string settings_scene7 = "If you want to return to the Main Menu press: Main Menu";
        string settings_scene8 = "If you want to see the whole tutorial again, Press the Button: Restart Tutorial";


        text_tutorial.text = settings_scene1;
        sm.PlaySound("Settings1");
        yield return new WaitForSeconds(4);

        text_tutorial.text = settings_scene2;
        sm.PlaySound("Settings2");
        yield return new WaitForSeconds(6);

        text_tutorial.text = settings_scene3;
        sm.PlaySound("Settings3");
        yield return new WaitForSeconds(3);
        StartCoroutine(HiglightComponent(text_id));
        StartCoroutine(HiglightComponent(input_id));
        yield return new WaitForSeconds(3);

        text_tutorial.text = settings_scene4;
        sm.PlaySound("Settings4");
        yield return new WaitForSeconds(7);
        StartCoroutine(HiglightComponent(text_size));
        StartCoroutine(HiglightComponent(input_size));
        text_tutorial.text = settings_scene5;
        sm.PlaySound("Settings5");
        yield return new WaitForSeconds(4);

        text_tutorial.text = settings_scene6;
        sm.PlaySound("Settings6");
        yield return new WaitForSeconds(4);
        StartCoroutine(HiglightComponent(button_Back));
        yield return new WaitForSeconds(2);

        text_tutorial.text = settings_scene7;
        sm.PlaySound("Settings7");
        yield return new WaitForSeconds(4);
        StartCoroutine(HiglightComponent(button_MainMenu));
        yield return new WaitForSeconds(2);

        text_tutorial.text = settings_scene8;
        sm.PlaySound("Settings8");
        yield return new WaitForSeconds(4);
        StartCoroutine(HiglightComponent(button_Restart));
        yield return new WaitForSeconds(2);
    }

    /// <summary>
    /// Tutorial for AR page
    /// </summary>
    IEnumerator TutorialAR()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");

        GameObject text_panel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        text_panel.SetActive(true);

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string ar_scene1 = "On this page a Supervisor will mark the Pill you selected to detect with a red arrow.";
        string ar_scene2 = "The red square represents the current mouse movement of a supervisor.";
        string ar_scene3 = "If you want to go to the detection page, press the Button: Back.";
        string ar_scene4 = "If you want to go back to the Home Screen press the Button: Main Menu.";


        text_tutorial.text = ar_scene1;
        sm.PlaySound("AR1");
        yield return new WaitForSeconds(5);

        text_tutorial.text = ar_scene2;
        sm.PlaySound("AR2");
        yield return new WaitForSeconds(5);

        text_tutorial.text = ar_scene3;
        sm.PlaySound("AR3");
        yield return new WaitForSeconds(5);
        StartCoroutine(HiglightComponent(button_Back));
        yield return new WaitForSeconds(5);

        text_tutorial.text = ar_scene4;
        sm.PlaySound("AR4");
        yield return new WaitForSeconds(5);
        StartCoroutine(HiglightComponent(button_MainMenu));
        yield return new WaitForSeconds(5);

        text_panel.SetActive(false);
    }

    /// <summary>
    /// Tutorial for KI page
    /// </summary>
    IEnumerator TutorialKI()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");
        GameObject button_ContactSupervisor = GameObject.Find("AR");

        GameObject text_panel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        text_panel.SetActive(true);

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string ki_scene1 = "Place the pills you want to detect on a surface inside the cameras view.";
        string ki_scene2 = "The Pill you selected for search on the previous page, will be indicated by a red Arrow.";
        string ki_scene3 = "If you have no clear result or unsure about the detection you can ask a supervisor for help.";
        string ki_scene4 = "Therefore press the Button: Contact Supervisor";
        string ki_scene5 = "If you want to change the Pill that is detected press the Button: Back";
        string ki_scene6 = "If you want to go back to the Home Screen press the Button: Main Menu";


        text_tutorial.text = ki_scene1;
        sm.PlaySound("KI1");
        yield return new WaitForSeconds(5);

        text_tutorial.text = ki_scene2;
        sm.PlaySound("KI2");
        yield return new WaitForSeconds(5);

        text_tutorial.text = ki_scene3;
        sm.PlaySound("KI3");
        yield return new WaitForSeconds(6);

        text_tutorial.text = ki_scene4;
        sm.PlaySound("KI4");
        yield return new WaitForSeconds(4);
        StartCoroutine(HiglightComponent(button_ContactSupervisor));
        yield return new WaitForSeconds(4);

        text_tutorial.text = ki_scene5;
        sm.PlaySound("KI5");
        yield return new WaitForSeconds(5);
        StartCoroutine(HiglightComponent(button_Back));
        yield return new WaitForSeconds(3);

        text_tutorial.text = ki_scene6;
        sm.PlaySound("KI6");
        yield return new WaitForSeconds(4);
        StartCoroutine(HiglightComponent(button_MainMenu));
        yield return new WaitForSeconds(4);

        text_panel.SetActive(false);
    }

    /// <summary>
    /// Tutorial for select pill page
    /// </summary>
    IEnumerator TutorialSelectPill()
    {
        GameObject button_MainMenu = GameObject.Find("Home");
        GameObject button_Back = GameObject.Find("Back");
        GameObject button_Aspirin = GameObject.Find("Aspirin");
        GameObject button_Ibuhexal = GameObject.Find("IbuHexal");
        GameObject button_Ibuprofen = GameObject.Find("IbuProfen");
        GameObject button_Thomapyrin = GameObject.Find("Thomapyrin");
        GameObject button_Sinupret = GameObject.Find("Sinupret");
        GameObject button_Gummibaerchen = GameObject.Find("Gummibaerchen");

        GameObject text_panel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        text_panel.SetActive(true);

        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();

        string pill_scene1 = "On this Site you can select the Pill you want to detect.";
        string pill_scene2 = "If you look for a certain pill, click on the respective button.";
        string pill_scene3 = "If you want to return to the previous page, press: Back";
        string pill_scene4 = "If you want to return to the Main Menu press: Main Menu";

        

        text_tutorial.text = pill_scene1;
        sm.PlaySound("SelectPill1");
        yield return new WaitForSeconds(5);

        text_tutorial.text = pill_scene2;
        sm.PlaySound("SelectPill2");
        yield return new WaitForSeconds(3);

        StartCoroutine(HiglightComponent(button_Aspirin));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HiglightComponent(button_Ibuhexal));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HiglightComponent(button_Ibuprofen));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HiglightComponent(button_Thomapyrin));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HiglightComponent(button_Sinupret));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HiglightComponent(button_Gummibaerchen));
        yield return new WaitForSeconds(0.3f);

        text_tutorial.text = pill_scene3;
        sm.PlaySound("SelectPill3");
        yield return new WaitForSeconds(3);
        StartCoroutine(HiglightComponent(button_Back));
        yield return new WaitForSeconds(3);

        text_tutorial.text = pill_scene4;
        sm.PlaySound("SelectPill4");
        yield return new WaitForSeconds(3);
        StartCoroutine(HiglightComponent(button_MainMenu));
        yield return new WaitForSeconds(3);
    }

    /// <summary>
    /// Tutorial for main menu
    /// </summary>
    IEnumerator TutorialMainMenu()
    {
        GameObject button_start = GameObject.Find("Start");
        GameObject button_settings = GameObject.Find("Settings");
        TextMeshProUGUI text_tutorial = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>(); ;

        string main_scene1 = "You are currently seeing the main menu.";
        string main_scene2 = "If you want to identify a pill or get further information about a pill, click: Detect Pill";
        string main_scene3 = "If you want to cusomize the application or get further assitance, click: Settings";

        text_tutorial.text = main_scene1;
        sm.PlaySound("MainMenu1");
        yield return new WaitForSeconds(4);

        text_tutorial.text = main_scene2;
        sm.PlaySound("MainMenu2");
        yield return new WaitForSeconds(5);
        StartCoroutine(HiglightComponent(button_start));
        yield return new WaitForSeconds(2);

        text_tutorial.text = main_scene3;
        sm.PlaySound("MainMenu3");
        yield return new WaitForSeconds(5);
        StartCoroutine(HiglightComponent(button_settings));
        yield return new WaitForSeconds(3);
    }


    /// <summary>
    /// Highlight component
    /// </summary>
    /// <param name="obj">object to be highlighted</param>
    private IEnumerator HiglightComponent(GameObject obj)
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
    private void placeCompanion()
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
