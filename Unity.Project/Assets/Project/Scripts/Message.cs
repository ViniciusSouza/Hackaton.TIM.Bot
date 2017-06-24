using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public Text txt;
    public Image iconChar;

    private ConversationWindow window;

    public GameObject prefabOpcao;
    public Transform containerBotoes;

    public List<GameObject> spawnedButtons;

    public void SetMessage(ConversationWindow _window, string message, Sprite character = null)
    {
        window = _window;
        txt.text = message;
        if(iconChar != null)
            iconChar.sprite = character;
    }
    /// <summary>
    /// Cria uma lista de opcoes a
    /// </summary>
    /// <param name="alternatives"></param>
    /// <param name="window"></param>
    public void SetAlternatives(string[] alternatives)
    {
        for (int x = 0; x < alternatives.Length; x++)
        {
            CreateButton(alternatives[x]);
        }
    }
    public void CreateButton(string alternative)
    {
        GameObject g = (GameObject)Instantiate(prefabOpcao, containerBotoes);
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one;
        g.transform.localRotation = Quaternion.identity;
        
        g.GetComponent<Button>().onClick.AddListener(() => ClickedButton(alternative));
        spawnedButtons.Add(g);
    }
    public void ClickedButton(string option)
    {
        //Manda para o controller a resposta
        window.EnviaMensagem(false, option);
        //Desabilita todos os botoes dessa mensagem
        for (int x = 0; x < spawnedButtons.Count; x++)
        {
            spawnedButtons[x].GetComponent<Button>().interactable = false;
        }
    }
}
