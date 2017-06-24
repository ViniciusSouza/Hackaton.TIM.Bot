using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.BotDirectLine;
using System;

public class BotController : MonoBehaviour {
    
    public MainController mainController;
    public delegate void OnMessageReceived(BotResponseEventArgs data);
    public event OnMessageReceived Evt_OnMessageReceived;

    //public MessageActivity data;

    public string[] tiposActivity;

    [System.Serializable]
    public class Conversation
    {
        public string ConversationId = "";
    }

    public Conversation _conversationState = new Conversation();

    private void Start()
    {
        BotDirectLineManager.Initialize("v-EKTLVRnMY.cwA.uVQ.hnXuX73CXibcI4diQcmWP0KAPBL7gxM1QiPB_w0mK1o");
        BotDirectLineManager.Instance.BotResponse += OnBotResponse;
        StartCoroutine(BotDirectLineManager.Instance.StartConversationCoroutine());
    }

    public void EnviaMensagem(string message, string userId, string userName)
    {
        StartCoroutine(BotDirectLineManager.Instance.SendMessageCoroutine(
                _conversationState.ConversationId, userId, message, userName));
    }
    public void StartBotAction(int index, string userId, string userName)
    {
        StartCoroutine(BotDirectLineManager.Instance.SendEventCoroutine(
                _conversationState.ConversationId, userId, tiposActivity[index], userName));
    }
    public void EndBotAction(int index, string userId, string userName)
    {
        //Tipo 3 é o reset
        StartCoroutine(BotDirectLineManager.Instance.SendEventCoroutine(
                _conversationState.ConversationId, userId, tiposActivity[3], userName));
    }

    private void OnBotResponse(object sender, Assets.BotDirectLine.BotResponseEventArgs e)
    {
        Debug.Log("OnBotResponse: " + e.ToString());

        switch (e.EventType)
        {
            case EventTypes.ConversationStarted:
                // Store the ID
                _conversationState.ConversationId = e.ConversationId;
                break;
            case EventTypes.MessageSent:
                if (!string.IsNullOrEmpty(_conversationState.ConversationId))
                {
                    // Get the bot's response(s)
                    StartCoroutine(BotDirectLineManager.Instance.GetMessagesCoroutine(_conversationState.ConversationId));
                }

                break;
            case EventTypes.MessageReceived:
                // Handle the received message(s)
                if (Evt_OnMessageReceived != null)
                {
                    Evt_OnMessageReceived(e);
                }
                break;
            case EventTypes.Error:
                // Handle the error
                break;
        }
    }
}
