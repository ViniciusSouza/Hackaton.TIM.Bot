using System;
using System.Collections;
using System.Collections.Generic;
using Assets.BotDirectLine;
using UnityEngine;

public class MainController : MonoBehaviour {

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(BotDirectLineManager.Instance.SendMessageCoroutine(
                _conversationState.ConversationId, "UnityUserId", "Hello bot!", "Unity User 1"));
        }
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
                break;
            case EventTypes.Error:
                // Handle the error
                break;
        }
    }
}
