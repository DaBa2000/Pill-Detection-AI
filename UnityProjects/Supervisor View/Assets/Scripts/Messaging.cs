using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        clientEventHandler = new RtmClientEventHandler();
        channelEventHandler = new RtmChannelEventHandler();
        callEventHandler = new RtmCallEventHandler();

        rtmClient = new RtmClient(appId, clientEventHandler);

        channelEventHandler.OnMessageReceived = OnChannelMessageReceivedHandler;

        Login();
    }

    // Update is called once per frame
    void Update()
    {
        if (!joined)
        {
            JoinChannel();
        }

        Debug.Log(GameController.GetAgoraID());
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
        UserName = GameController.GetAgoraID() + "view";

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

        Debug.Log("Joined Channel " + ChannelName);
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
        string coord = message.GetText();
        Debug.Log(message.GetText());
        joined = true;
    }
}
