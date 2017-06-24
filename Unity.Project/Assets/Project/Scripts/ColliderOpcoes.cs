using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Areas onde inicia uma interacao com um personagem (abre um menu) 
/// </summary>
public class ColliderOpcoes : MonoBehaviour {

    public MainController controller;


    public enum BOT_TYPE
    {
        DetalhesConta,
        Faq,
        Servicos,
        Minigame,
        Center
    }
    public BOT_TYPE thisType;

    public void OnTriggerEnter(Collider other)
    {
        if (thisType != BOT_TYPE.Center)
            controller.OpenCharacter(thisType);
        else
        {
            controller.GetBackToCenter();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (thisType != BOT_TYPE.Center)
            controller.ExitCharacter(thisType);
        else
        {
            controller.ExitCenter();
        }
    }
}
