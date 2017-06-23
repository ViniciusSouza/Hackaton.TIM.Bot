using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla a janela de conversaçao
/// </summary>
public class ConversationWindow : MonoBehaviour {

    public MainController mainController;

    public GameObject prefabBotMessage;
    public GameObject prefabPlayerAnswer;

    public Transform containerMessages;
    public List<GameObject> spawnedMessages;

    public Talent.BaseSlide messageWindow;

    public int currentCharacter = 0;
    public Sprite[] charactersIcons;

    public InputField inputMensagem;

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
        OpenWindow(true);
    }
    public void OpenWindow(bool cmd)
    {
        messageWindow.SetSlideActive(cmd);
    }
    public void AddBotMessageWithButtons()
    {
        //TODO
    }
    public void AddBotMessage(string message)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabBotMessage, containerMessages);
        g.GetComponent<Message>().SetMessage(message, charactersIcons[currentCharacter]);
        AddMessage(g);
    }
    public void AddPlayerMessage(string message)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabPlayerAnswer, containerMessages);
        g.GetComponent<Message>().SetMessage(message);
        AddMessage(g);
    }
    private void AddMessage(GameObject obj)
    {
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

        spawnedMessages.Add(obj);
    }
    /// <summary>
    /// Determina se adiciona o visual na lista de mensagens
    /// </summary>
    /// <param name="addVisual"></param>
    public void EnviaMensagem(bool addVisual)
    {
        //Pega a mensagem do jogaodr
        string input = inputMensagem.text;

        //Limpa o input de mensagem
        inputMensagem.text = "";

        if (addVisual)
        {
            AddPlayerMessage(input);
        }

        mainController.EnviaMensagem(input);
    }
}
