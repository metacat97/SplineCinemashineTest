using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using System;
using Photon.Chat.Demo;
using ExitGames.Client.Photon;

public class PhotonChatController : MonoBehaviour, IChatClientListener
{
    [SerializeField] private string nickName;
    private ChatClient chatClient;

    private void Awake()
    {
        nickName = PlayerPrefs.GetString("USERNAME");
    }

    void Start()
    {
        chatClient = new ChatClient(this);
        ConnectToPhotonChat();
    }
    private void Update()
    {
        chatClient.Service();
    }
    private void ConnectToPhotonChat()
    {
        Debug.Log("Connecting to Photon Chat");
        chatClient.AuthValues = new Photon.Chat.AuthenticationValues(nickName);
        ChatAppSettings chatSettings = PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings();
        chatClient.ConnectUsingSettings(chatSettings);
    }

    public void SendDirectMessage(string recipient, string message)
    {
        chatClient.SendPrivateMessage(recipient, message);
    }

    public void DebugReturn(DebugLevel level, string message)
    {
    }


    public void OnDisconnected()
    {
        Debug.Log("³Í ¿¬°áÇØÁ¦µÆ´Ù Æ÷Åæ Ã¤ÆÃ¿¡");
    }

    public void OnConnected()
    {
        Debug.Log("³Í ¿¬°áµÆ´Ù Æ÷Åæ Ã¤ÆÃ¿¡");
        SendDirectMessage("mola", "ÀÌ°Ô dddddddd¸Â³Ä!");
    }

    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {

    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        string[] splitNames = channelName.Split(new char[] { ':' });
        string senderName = splitNames[0];
        if(!sender.Equals(senderName, StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log($"{sender}: {message}");
        }
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {

    }

    public void OnUnsubscribed(string[] channels)
    {

    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {

    }

    public void OnUserUnsubscribed(string channel, string user)
    {
         
    }
}
