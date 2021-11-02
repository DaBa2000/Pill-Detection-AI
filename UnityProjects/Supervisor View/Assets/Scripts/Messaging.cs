using System.Collections;
using System.Collections.Generic;
using agora_rtm;
using UnityEngine;

public class Messaging : MonoBehaviour
{
    // Event handlers
    RtmClientEventHandler clientEventHandler;
    RtmChannelEventHandler channelEventHandler;

    // chat client
    RtmClient rtmClient;
    RtmChannel channel;

    // app id and toke, connection app to agora project
    string appId = "41ad377e7f2d4700b2f72bba1660f421";
    string token = "";

    string UserName;
    bool joined = false;

    // Start is called before the first frame update
    void Start()
    {
        // set event handlers
        clientEventHandler = new RtmClientEventHandler();
        channelEventHandler = new RtmChannelEventHandler();
        channelEventHandler.OnMessageReceived = OnChannelMessageReceivedHandler;

        // create new client based on appid
        rtmClient = new RtmClient(appId, clientEventHandler);
        
        // login to chanel
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

    /// <summary>
    /// Login to text channels
    /// </summary>
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

    /// <summary>
    /// Logout of text channel
    /// </summary>
    public void Logout()
    {
        rtmClient.Logout();
    }

    /// <summary>
    /// join certain text channel
    /// </summary>
    public void JoinChannel()
    {
        string ChannelName = GameController.GetAgoraID() + "txt";
        channel = rtmClient.CreateChannel(ChannelName, channelEventHandler);
        channel.Join();

        Debug.Log("Joined Channel " + ChannelName);
    }

    /// <summary>
    /// leave certain text channel
    /// </summary>
    public void LeaveChannel()
    {
        channel.Leave();
    }

    /// <summary>
    /// send message to text channel
    /// </summary>
    /// <param name="message">message to send</param>
    public void SendMessageToChannel(string message)
    {
        channel.SendMessage(rtmClient.CreateMessage(message));
    }

    /// <summary>
    /// handle message when recieven from other user
    /// </summary>
    /// <param name="id">id of messsage</param>
    /// <param name="userId">user id of message sender</param>
    /// <param name="message">message content</param>
    void OnChannelMessageReceivedHandler(int id, string userId, TextMessage message)
    {
        string coord = message.GetText();
        Debug.Log(message.GetText());
        joined = true;
    }
}
