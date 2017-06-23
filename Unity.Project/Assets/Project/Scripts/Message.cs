using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public Text txt;
    public Image iconChar;

    public void SetMessage(string message, Sprite character = null)
    {
        txt.text = message;
        if(iconChar != null)
            iconChar.sprite = character;
    }
}
