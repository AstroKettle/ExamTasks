using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : NetworkBehaviour
{
    [SerializeField] private ChatMessage _chatMessagePrefab;
    [SerializeField] private Transform _messageParent;
    [SerializeField] private TMP_InputField _chatInputField;
    [SerializeField] private Button _sendButton;

    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;

    private const int MaxNumberOfMessagesInList = 20;
    private List<ChatMessage> _messages;

    private void Start()
    {
        _messages = new List<ChatMessage>();

        _sendButton.onClick.AddListener(OnSendButtonClicked);
        _hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        _clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });

        NetworkManager.OnClientConnectedCallback += (x) => Debug.Log("CONNECTED");
        NetworkManager.OnServerStarted += () => Debug.Log("SERVER STARTED");
        NetworkManager.OnClientStarted += () => Debug.Log("CLIENT STARTED");
        NetworkManager.OnClientStopped += (x) => Debug.Log("CLIENT STOPPED");
        NetworkManager.OnServerStopped += (x) => Debug.Log("SERVER STOPPED");
    }

    private void OnServerInitialized()
    {
        print("SERVER INITIALIAZED");
    }

    private void OnConnectedToServer()
    {
        print("SERVER CONNECTED");

    }


    private void OnDestroy()
    {
        _sendButton.onClick.RemoveListener(OnSendButtonClicked);
    }

    private void OnSendButtonClicked()
    {
        SendMessage();
        _chatInputField.Select();
    }

    private void SendMessage()
    {
        string message = _chatInputField.text;
        _chatInputField.text = "";

        if (!string.IsNullOrWhiteSpace(message))
            SendChatMessageServerRpc(message, NetworkManager.Singleton.LocalClientId);
    }

    [ServerRpc(RequireOwnership = false)]
    private void SendChatMessageServerRpc(string message, ulong senderPlayerId)
    {
        ReceiveChatMessageClientRpc(message, senderPlayerId);
    }

    [ClientRpc]
    private void ReceiveChatMessageClientRpc(string message, ulong senderPlayerId)
    {
        AddMessage(message, senderPlayerId);
    }

    private void AddMessage(string message, ulong senderPlayerId)
    {
        var msg = Instantiate(_chatMessagePrefab, _messageParent);
        msg.SetMessage($"Player{senderPlayerId}", message);

        _messages.Add(msg);

        if (_messages.Count > MaxNumberOfMessagesInList)
        {
            Destroy(_messages[0]);
            _messages.RemoveAt(0);
        }
    }
}
