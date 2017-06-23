using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ponto de controle geral da aplicacao, interage com as aberturas de popup e recebe os comandos basicos de navegacao
/// </summary>
public class MainController : MonoBehaviour {
    
    [System.Serializable]
    public class UserData
    {
        public string userName = "Atento Hackaton";
        public string userId = "123456";
    }

    public UserData thisUser = new UserData();

    /// <summary>
    /// Slides de mostram as perguntas que os personagens fazem (os 3 bots + o de minigame)
    /// </summary>
    public Talent.BaseSlide[] charactersInteraction;

    public ConversationWindow conversationController;
    public BotController botController;
    public MyCharacterController characterController;

    public int currentOpenActivity = -1;
    
    public void OpenCharacter(ColliderOpcoes.BOT_TYPE index)
    {
        charactersInteraction[(int)index].SetSlideActive(true);
    }
    /// <summary>
    /// Faz uma interacao de foco num personagem
    /// </summary>
    /// <param name="index"></param>
    public void FocusOn(int index, bool isFocusIn)
    {

    }
    /// <summary>
    /// Abre a atividade de um bot especifico
    /// </summary>
    /// <param name="index"></param>
    public void OpenBotActivity(int index)
    {
        currentOpenActivity = index;
        //Abre a interacao no botController
        botController.StartBotAction(index);
        //Abre a conversacao
        conversationController.OpenWindow(true);
        //Foca no personagem
        FocusOn(index, true);
    }
    /// <summary>
    /// Abre o minigame em si
    /// </summary>
    public void OpenMinigame()
    {

    }
    public void ExitCharacter(ColliderOpcoes.BOT_TYPE index)
    {
        charactersInteraction[(int)index].SetSlideActive(false);
        if (currentOpenActivity != -1)
        {
            //Fecha a atividade no botController
            botController.EndBotAction(currentOpenActivity);
            currentOpenActivity = -1;

            //Fecha o popup de conversacao
            conversationController.OpenWindow(false);

            //Desfoca
            FocusOn(-1, false);
        }
    }
    public void EnviaMensagem(string input)
    {
        botController.EnviaMensagem(input, thisUser.userId, thisUser.userName);
    }
}
