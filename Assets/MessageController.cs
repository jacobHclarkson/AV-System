using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject textDisplayObject;
    [SerializeField] Text messageDisplay;
    [SerializeField] GameObject avCue;
    [SerializeField] GameObject closeMessageCue;

    public string message1 = "Find the Temple of the Horse.";
    public string message2 = "Explore the Temple of the Horse.";
    public string message3 = "Find the Temple of the Lion.";
    public string message4 = "Explore the Temple of the Lion.";
    public string message5 = "Find the key in the Temple of the Horse.";
    public string message6 = "Find the Temple of the Dragon.";
    public string message7 = "Explore the Temple of the Dragon.";
    public string message8 = "Find the Dragon Idol in the Temple of the Lion.";

    void Start()
    {
        // display first message
        if(!textDisplayObject.activeSelf)
            ToggleMessage();
        SetMessage(message1);
    }
    
    void Update()
    {
        // check for player toggling message
        if (Input.GetKeyDown(KeyCode.M) || Input.GetButtonDown("B Button"))
        {
            ToggleMessage();
        }
    }

    // switch message on/off
    void ToggleMessage()
    {
        textDisplayObject.SetActive(!textDisplayObject.activeSelf);
        closeMessageCue.SetActive(!closeMessageCue.activeSelf);
    }

    public void SetAVCue(bool b)
    {
        avCue.SetActive(b);
    }

    public void ToggleAVCue()
    {
        avCue.SetActive(!avCue.activeSelf);
    }

    public void SetMessage(string message)
    {
        messageDisplay.text = message;
    }
}
