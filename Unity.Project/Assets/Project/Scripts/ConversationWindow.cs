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
    
    public Sprite[] charactersIcons;

    public InputField inputMensagem;

    public int count = 0;

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
        //Adiciona o listener de mensagens do bot
        mainController.botController.Evt_OnMessageReceived += BotController_Evt_OnMessageReceived;
        OpenWindow(true);
    }

    /// <summary>
    /// Lida com a mensagem recebida
    /// </summary>
    /// <param name="data"></param>
    private void BotController_Evt_OnMessageReceived(Assets.BotDirectLine.BotResponseEventArgs data)
    {
        //Sempre pega o ultimo watermark
        int watermark = int.Parse(data.Watermark) - 1;
        //Avalia a mensagem recebida
        //TODO (filtrar caso seja botoes)
        AddBotMessage(data.Messages[watermark].Text);
    }

    public void OpenWindow(bool cmd)
    {
        messageWindow.SetSlideActive(cmd);
        if (cmd == false)
        {
            //Remove o listener de mensagens do bot
            mainController.botController.Evt_OnMessageReceived -= BotController_Evt_OnMessageReceived;
        }
    }
    public void AddBotMessageWithButtons(string message, string[] buttons)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabBotMessage, containerMessages);
        g.GetComponent<Message>().SetMessage(this, message, charactersIcons[mainController.currentOpenActivity]);
        g.GetComponent<Message>().SetAlternatives(buttons);
        AddMessage(g);
    }
    public void AddBotMessage(string message)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabBotMessage, containerMessages);
        g.GetComponent<Message>().SetMessage(this, message, charactersIcons[mainController.currentOpenActivity]);
        AddMessage(g);
    }
    public void AddPlayerMessage(string message)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabPlayerAnswer, containerMessages);
        g.GetComponent<Message>().SetMessage(this, message);
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
    public void EnviaMensagem(bool addVisual, string text = "")
    {
        //Pega a mensagem do jogaodr
        string input = inputMensagem.text;
        if(text != "")
            input = text;

        //Limpa o input de mensagem
        inputMensagem.text = "";

        if (addVisual)
        {
            AddPlayerMessage(input);
        }

        mainController.EnviaMensagem(input);
    }
}
