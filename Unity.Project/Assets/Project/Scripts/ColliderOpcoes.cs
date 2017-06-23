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
        Servicos,
        Faq,
        Minigame
    }
    public BOT_TYPE thisType;

    public void OnTriggerEnter(Collider other)
    {
        controller.OpenCharacter(thisType);
    }
    public void OnTriggerExit(Collider other)
    {
        controller.ExitCharacter(thisType);
    }
}
