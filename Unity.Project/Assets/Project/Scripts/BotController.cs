﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.BotDirectLine;
using System;

public class BotController : MonoBehaviour {
    
    public MainController mainController;
    public delegate void OnMessageReceived(BotResponseEventArgs data);
    public event OnMessageReceived Evt_OnMessageReceived;

    [System.Serializable]
    public class Conversation
    {
        public string ConversationId = "";
    }

    public Conversation _conversationState = new Conversation();

    private void Start()
    {
        BotDirectLineManager.Initialize("WqKHIPdeZIw.cwA.qLU.Emp65KL245rQf80GI-QMrnhM4AD6dASW8dGd2VCCtTI");
        BotDirectLineManager.Instance.BotResponse += OnBotResponse;
        StartCoroutine(BotDirectLineManager.Instance.StartConversationCoroutine());
    }

    public void EnviaMensagem(string message, string userId, string userName)
    {
        StartCoroutine(BotDirectLineManager.Instance.SendMessageCoroutine(
                _conversationState.ConversationId, userId, message, userName));
    }
    public void StartBotAction(int index)
    {

    }
    public void EndBotAction(int index)
    {

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
