using System.Collections;
using System.Globalization;
using agora_rtm;
using UnityEngine;

public class Messaging : MonoBehaviour
{
    // Event handlers for chat actions
    RtmClientEventHandler clientEventHandler;
    RtmChannelEventHandler channelEventHandler;

    // client managing the chat interactions
    RtmClient rtmClient;
    // channel under which communication runs
    RtmChannel channel;

    // id and token under which the app streams text and video
    string appId = "41ad377e7f2d4700b2f72bba1660f421";
    string token = "";

    string UserName;

    bool joined = false;
    bool message_recieved = false;

    // manage arrow placement 
    public GameObject ArrowPlacementManager;
    ArrowPlacement AP;
    public Material arrowMaterialGreen;


    // Start is called before the first frame update
    void Start()
    {
        // get the channel connection client and caregiver from PlayerPrefs
        GameController.SetAgoraID(PlayerPrefs.GetString("agoraID"));

        // set event handlers
        clientEventHandler = new RtmClientEventHandler();
        channelEventHandler = new RtmChannelEventHandler();
        channelEventHandler.OnMessageReceived = OnChannelMessageReceivedHandler;

        // create RTMClient for this app and this appID
        rtmClient = new RtmClient(appId, clientEventHandler);

        // Login to the app
        Login();
        // Join the text channel
        JoinChannel();

        // get Arrow Placement Manager from scene in order to manage the arrow placement
        AP = ArrowPlacementManager.GetComponent<ArrowPlacement>();

        // Set debug message if no id has been set
        if (GameController.GetAgoraID() == null || GameController.GetAgoraID() == "")
        {
            GameObject debug_agoraid = GameObject.Find("Canvas").transform.Find("debug_agoraid").gameObject;
            debug_agoraid.SetActive(true);
        }

        // Set debug message if wifi connection is impossible
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject debug_wifi = GameObject.Find("Canvas").transform.Find("debug_wifi").gameObject;
            debug_wifi.SetActive(true);
        }

        // Check if caregiver is found via streaming id
        StartCoroutine(checkStreamReciever());
    }

    /// <summary>
    /// Check if CareGiver is reachable under AgoraID
    /// </summary>
    IEnumerator checkStreamReciever()
    {
        yield return new WaitForSeconds(5);
        if (!message_recieved)
        {
            GameObject debug_connection = GameObject.Find("Canvas").transform.Find("debug_connection").gameObject;
            debug_connection.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!joined)
        {
            JoinChannel();
        }
    }

    void OnApplicationQuit()
    {
        if (channel != null)
        {
            channel.Dispose();
            channel = null;
        }
        if (rtmClient != null)
        {
            rtmClient.Dispose();
            rtmClient = null;
        }
    }

    /// <summary>
    /// Login to text chat of application
    /// </summary>
    public void Login()
    {
        UserName = "stream";

        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(appId))
        {
            Debug.LogError("We need a username and appId to login");
            return;
        }

        rtmClient.Login(token, UserName);
    }

    /// <summary>
    /// Logout of text chat of application
    /// </summary>
    public void Logout()
    {
        rtmClient.Logout();
    }

    /// <summary>
    /// Join certain text channel
    /// </summary>
    public void JoinChannel()
    {
        // set channel name to AgoraID + "txt" therefore agoraID has only to be set once
        string ChannelName = GameController.GetAgoraID() + "txt";
        // create text channel
        channel = rtmClient.CreateChannel(ChannelName, channelEventHandler);
        channel.Join();
    }

    /// <summary>
    /// Leave certain text channel
    /// </summary>
    public void LeaveChannel()
    {
        channel.Leave();
    }

    /// <summary>
    /// Send a message to current text channel
    /// </summary>
    /// <param name="message">message that is sent to the channel</param>
    public void SendMessageToChannel(string message)
    {
        channel.SendMessage(rtmClient.CreateMessage(message));
    }

    /// <summary>
    /// Handle recieved messages
    /// </summary>
    /// <param name="id">id of recieved message</param>
    /// <param name="userId">id of sender of message</param>
    /// <param name="message">text content of the message</param>
    void OnChannelMessageReceivedHandler(int id, string userId, TextMessage message)
    {
        message_recieved = true;
        joined = true;

        // convert text message to single words
        string msg = message.GetText().Replace(',', '.');
        string[] part = msg.Split(' ');

        // if first word is coord, the message contains coordinates where the placement indicator should be placed
        if (part[0].Equals("coord"))
        {
            // get x and y coordinates, convert the to en-US decimal point format and save position
            // if clck is outside of bounds, it is ignored
            float x_pos = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            if (x_pos > 0 && x_pos < 1)
            {
                GameController.marker_x = x_pos;
            }

            float y_pos = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);
            if (y_pos > 0 && y_pos < 1)
            {
                GameController.marker_y = y_pos;
            }
        }

        // if first word is arr, the message contains coordinates where the arrow sould be placed
        if (part[0].Equals("arr"))
        {
            // get x and y coordinates, convert the to en-US decimal point format and save position
            GameController.arrow_x = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            GameController.arrow_y = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);

            // place the AR arrow
            AP.setArrow();
        }

        // if first word is confirmPlacement, the arrow is turned green
        if (part[0].Equals("confirmPlacement"))
        {
            AP.setArrowMaterial(arrowMaterialGreen);
        }
    }
}
