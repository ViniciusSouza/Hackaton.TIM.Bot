using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla a janela de conversaçao
/// </summary>
public class ConversationWindow : MonoBehaviour {

    public GameObject prefabBotMessage;
    public GameObject prefabPlayerAnswer;

    public Transform containerMessages;
    public List<GameObject> spawnedMessages;

    public void Reset()
    {
        for (int x = 0; x < spawnedMessages.Count; x++)
        {
            Destroy(spawnedMessages[x]);
        }
        spawnedMessages = new List<GameObject>();
    }
    public void StartNewConversation()
    {
        Reset();
    }
    public void AddBotMessage(string message)
    {

    }
    public void AddPlayerMessage(string message)
    {

    }
    private void AddMessage(GameObject obj)
    {

    }
    public void SendMessage()
    {

    }
}
