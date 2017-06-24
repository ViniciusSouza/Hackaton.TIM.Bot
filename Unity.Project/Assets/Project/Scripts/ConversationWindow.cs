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
    public GameObject prefabBotFatura;
    public GameObject prefabPlayerAnswer;

    public Transform containerMessages;
    public List<GameObject> spawnedMessages;

    public Talent.BaseSlide messageWindow;
    
    public Sprite[] charactersIcons;

    public InputField inputMensagem;

    public Content attachmentDebug = new Content();
    public TextAsset txtJson;

    public int count = 0;

    private void Start()
    {
        attachmentDebug = JsonUtility.FromJson<Content>(txtJson.text);
    }
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
        bool isAttachment = false;
        /*if (data.Messages[watermark].Attachments.Count > 0)
        {
            //Nao estou tratando muitplos attachments
            isAttachment = true;
        }*/

        if (isAttachment)
        {
            switch (data.Messages[watermark].Attachments[0].contentType)
            {
                case "application/vnd.microsoft.card.hero":
                    //Botoes
                    string[] buttons = new string[data.Messages[watermark].Attachments[0].content[0].buttons.Count];
                    for (int x = 0; x < buttons.Length; x++)
                    {
                        buttons[x] = data.Messages[watermark].Attachments[0].content[0].buttons[x].value;
                    }
                    AddBotMessageWithButtons(data.Messages[watermark].Text, data.Messages[watermark].Attachments[0].content[0].content, buttons);
                    break;
                case "fatura":
                    //Informacoes de fatura
                    AddBotFatura(data.Messages[watermark].Text, data.Messages[watermark].Attachments[0].content[0]);
                    break;
                default:
                    AddBotMessage(data.Messages[watermark].Text);
                    break;
            }
        }
        else
        {
            AddBotMessage(data.Messages[watermark].Text);
        }
        //AddBotMessageWithButtons("Teste", new string[2] { "Sim", "Não" });
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
    public void AddBotFatura(string message, Content content)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabBotFatura, containerMessages);
        g.GetComponent<FaturaMessage>().SetMessage(this, message, content);
        AddMessage(g);
    }
    public void AddBotMessageWithButtons(string message, string extraQuestion, string[] buttons)
    {
        //Spanwa
        GameObject g = (GameObject)Instantiate(prefabBotMessage, containerMessages);
        g.GetComponent<Message>().SetMessage(this, message + "\n" + extraQuestion, charactersIcons[mainController.currentOpenActivity]);
        g.GetComponent<Message>().SetAlternatives(buttons);
        AddMessage(g);
    }
    public void AddBotMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

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
    public void EnviaMensagem()
    {
        EnviaMensagem(true);
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

        //ToDO - meu deus
        if (mainController.currentOpenActivity == 1)
        {
            mainController.EnviaMensagem(input);
        }
        else
        {
            AddBotFatura("Sua conta:", attachmentDebug);
            Debug.Log("Esta tentando mandar de outro");
        }
    }
}
