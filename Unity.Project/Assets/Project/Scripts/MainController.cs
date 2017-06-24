using System.Collections;
using System.Collections.Generic;
using Talent;
using UnityEngine;

/// <summary>
/// Ponto de controle geral da aplicacao, interage com as aberturas de popup e recebe os comandos basicos de navegacao
/// Esta muito ligaod a UI, entao funciona tambem como UI controller (TODO - Ajustar isso)
/// </summary>
public class MainController : MonoBehaviour {
    
    [System.Serializable]
    public class UserData
    {
        public string userName = "Atento Hackaton";
        public string userId = "123456";
    }

    public UserData thisUser = new UserData();

    public CanvasGroup fadeInicio;

    /// <summary>
    /// Slides de mostram as perguntas que os personagens fazem (os 3 bots + o de minigame)
    /// </summary>
    public Talent.BaseSlide[] charactersInteraction;
    public Talent.BaseSlide mainMenuIntro;
    public Talent.BaseSlide backMenus;

    public CameraController cameraController;
    public ConversationWindow conversationController;
    public BotController botController;
    public MyCharacterController characterController;

    public int currentOpenActivity = -1;

    private void Start()
    {
        GetBackToCenter();
        LeanTween.alphaCanvas(fadeInicio, 0f, 0.6f).setDelay(0.5f);
    }
    public void OpenCharacter(ColliderOpcoes.BOT_TYPE index)
    {
        charactersInteraction[(int)index].SetSlideActive(true);
        
        backMenus.SetSlideActive(true);
    }
    public void GetBackToCenter()
    {
        mainMenuIntro.SetSlideActive(true);
    }
    public void ExitCenter()
    {
        mainMenuIntro.SetSlideActive(false);
    }
    /// <summary>
    /// Faz uma interacao de foco num personagem
    /// </summary>
    /// <param name="index"></param>
    public void FocusOn(int index, bool isFocusIn)
    {
        if (!isFocusIn)
        {
            cameraController.RestoreOldFocus();
        }
        else
        {
            cameraController.FocusSomething(charactersInteraction[(int)index].targetLook, charactersInteraction[(int)index].offset, charactersInteraction[(int)index].lookOffset);
        }
    }
    /// <summary>
    /// Abre a atividade de um bot especifico
    /// </summary>
    /// <param name="index"></param>
    public void OpenBotActivity(int index)
    {
        //Fecha menu
        backMenus.SetSlideActive(false);
        charactersInteraction[(int)index].SetSlideActive(false);

        currentOpenActivity = index;
        //Abre a interacao no botController
        botController.StartBotAction(index);
        //Abre a conversacao
        conversationController.StartNewConversation();
        //Foca no personagem
        FocusOn(index, true);
    }
    /// <summary>
    /// Abre o minigame em si
    /// </summary>
    public void OpenMinigame()
    {

    }
    public void ExitCharacter()
    {
        if (currentOpenActivity != -1)
        {
            //Fecha a atividade no botController
            botController.EndBotAction(currentOpenActivity);
            currentOpenActivity = -1;

            //Fecha o popup de conversacao
            conversationController.OpenWindow(false);

            //Desfoca
            FocusOn(-1, false);

            characterController.MoveToTarget(4);
        }
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
        backMenus.SetSlideActive(false);
    }
    public void EnviaMensagem(string input)
    {
        botController.EnviaMensagem(input, thisUser.userId, thisUser.userName);
    }
}
