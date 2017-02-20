using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// this script will control when the typing container hides/shows to the player.

public class TypingContainerController : MonoBehaviour {

    [SerializeField] GameObject typingContainer;
    InputField inputField;

    // whether or not to show the typing box
    bool show = true;

    // string entered by user
    string finalInputString;
    string rawInputString;

    // stuff for timing
    System.DateTime startTime;
    System.TimeSpan timeElapsed;

    void Start()
    {
        ToggleShow();
    }

    void Update()
    {
        PollForInput();
        CaptureRawInput();
    }

    void PollForInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            show = !show;
            ToggleShow();
        }
    }

    void CaptureRawInput()
    {
        if (show)
        {
            foreach (char c in Input.inputString)
            {
                if(c == "\b"[0])
                {
                    rawInputString += '~';
                }
                rawInputString += c;
            }
        }
    }

    void ToggleShow()
    {
       
        if (show)
        {
            // show typing container
            typingContainer.SetActive(true);

            // simulate mouse click in input field (get focus)
            inputField = GetComponentInChildren<InputField>();
            inputField.Select();

            // note start time
            startTime = System.DateTime.Now;
        }
        else
        {
            // record text
            finalInputString = inputField.text;
            Debug.Log(finalInputString);
            Debug.Log(rawInputString);

            // record time
            timeElapsed = System.DateTime.Now - startTime;
            Debug.Log(timeElapsed.ToString());

            // delete stored text
            inputField.text = "";
            rawInputString = "";

            // hide typing container
            typingContainer.SetActive(false);
        }
    }
}
