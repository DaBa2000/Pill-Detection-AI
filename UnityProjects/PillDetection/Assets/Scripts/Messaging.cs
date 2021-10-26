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
        joined = true;

        string msg = message.GetText().Replace(',', '.');
        string[] part = msg.Split(' ');

        if (part[0].Equals("coord"))
        {
            GameController.marker_x = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            GameController.marker_y = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);
        }

        if (part[0].Equals("arr"))
        {
            GameController.arrow_x = float.Parse(part[1], new CultureInfo("en-US").NumberFormat);
            GameController.arrow_y = float.Parse(part[2], new CultureInfo("en-US").NumberFormat);

            AP.setArrow();
        }
    }
}
