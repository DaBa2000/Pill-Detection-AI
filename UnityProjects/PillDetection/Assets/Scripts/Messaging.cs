using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using agora_rtm;
using UnityEngine;

public class Messaging : MonoBehaviour
{

    RtmClientEventHandler clientEventHandler;
    RtmChannelEventHandler channelEventHandler;
    RtmCallEventHandler callEventHandler;

    RtmClient rtmClient;

    string appId = "41ad377e7f2d4700b2f72bba1660f421";
    string token = "";

    RtmChannel channel;
    string UserName;

    bool joined = false;

    public GameObject ArrowPlacementManager;
    ArrowPlacement AP;

    public Material arrowMaterialGreen;

    public bool message_recieved = false;

    // Start is called before the first frame update
    void Start()
    {
        GameController.SetAgoraID(PlayerPrefs.GetString("agoraID"));

        clientEventHandler = new RtmClientEventHandler();
        channelEventHandler = new RtmChannelEventHandler();
        callEventHandler = new RtmCallEventHandler();

        rtmClient = new RtmClient(appId, clientEventHandler);

        channelEventHandler.OnMessageReceived = OnChannelMessageReceivedHandler;

        Login();
        JoinChannel();

        AP = ArrowPlacementManager.GetComponent<ArrowPlacement>();

        if (GameController.GetAgoraID() == null || GameController.GetAgoraID() == "")
        {
            GameObject debug_agoraid = GameObject.Find("Canvas").transform.Find("debug_agoraid").gameObject;
            debug_agoraid.SetActive(true);
        }

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject debug_wifi = GameObject.Find("Canvas").transform.Find("debug_wifi").gameObject;
            debug_wifi.SetActive(true);
        }

        StartCoroutine(checkStreamReciever());
    }

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

        Debug.Log("AGORAID: " + GameController.GetAgoraID());
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

    public void Logout()
    {
        rtmClient.Logout();
    }

    public void JoinChannel()
    {
        string ChannelName = GameController.GetAgoraID() + "txt";
        channel = rtmClient.CreateChannel(ChannelName, channelEventHandler);
        channel.Join();
    }

    public void LeaveChannel()
    {
        channel.Leave();
    }

    public void SendMessageToChannel(string message)
    {
        channel.SendMessage(rtmClient.CreateMessage(message));
    }

    void OnChannelMessageReceivedHandler(int id, string userId, TextMessage message)
    {
        message_recieved = true;

        joined = true;

        string msg = message.GetText().Replace(',', '.');
        string[] part = msg.Split(' ');

        if (part[0].Equals("coord"))
        {
            float x_pos = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            if (x_pos > 0 && x_pos < 1)
            {
                GameController.marker_x = x_pos;
            }

            float y_pos = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);
            if (x_pos > 0 && x_pos < 1)
            {
                GameController.marker_y = y_pos;
            }
        }

        if (part[0].Equals("arr"))
        {
            GameController.arrow_x = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            GameController.arrow_y = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);

            AP.setArrow();
        }

        if (part[0].Equals("confirmPlacement"))
        {
            AP.setArrowMaterial(arrowMaterialGreen);
        }
    }
}
