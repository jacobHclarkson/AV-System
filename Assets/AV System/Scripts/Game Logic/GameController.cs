﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // BASIC OR AV TUTORIAL
    private bool basic = false;

    // AV elements
    public GameObject leftViewport;
    public GameObject rightViewport;
    public GameObject webCamScreen;
    public GameObject leapSpace;

    // HUD canvas
    public GameObject hud;
    public GameObject promptObj;

    // Reticle
    public GameObject reticle;

    // text display
    public Text textPrompt;

    // image display
    public GameObject imageObj;
    public Image image;

    // textures for image display
    public Sprite allButtons;
    public Sprite buttonA;
    public Sprite buttonB;
    public Sprite buttonX;
    public Sprite buttonY;

    // objectives
    public GameObject leftCube;
    public GameObject rightCube;
    public GameObject frontCircle;
    public GameObject backCircle;
    public GameObject button;

    // move targets

    // basic messages
    private string prompt_0 = "Hello! Welcome to the tutorial stage. In this tutorial, you will learn how to move and interact in VR. Press the 'A' button on your controller to continue.";
    private string prompt_1 = "To look around, turn your head. Look at the red cube to your left until it turns green. First, dismiss this message by pressing 'A'.";
    private string prompt_2 = "Excellent! Now look at the red cube on your right until it turns green. First, dismiss this message by pressing 'A'.";
    private string prompt_3 = "Great. Now lets try moving around. To move, push the left analog stick forward or backward. Try moving into the red circle now.";
    private string prompt_4 = "Well done. Now move to the red circle behind you.";
    private string prompt_5 = "Very good. Now we'll learn how to interact with objects. Walk over to the red button and press 'A' to activate it.";
    private string prompt_6 = "That's it for the tutorial. Press 'A' to exit.";

    // av messages
    private string prompt_7 = "Now you will learn to see through the device you are wearing into the real world.";

    // bools and things to control coroutines
    private int tutorialStage = 0;
    bool one = true;
    bool two = true;
    bool three = false;
    bool four = false;
    bool five = false;
    bool six = false;
    bool seven = false;
    bool eight = false;
    bool nine = false;
    bool ten = false;
    bool eleven = false;
    bool twelve = true;

	// Use this for initialization
	void Start () {
        ToggleActive(hud);
        SetTextDisplay(prompt_0);
        SetImageDisplay(buttonA);

        // first message transition
        StartCoroutine(WaitForInputMessage("A Button", prompt_1)); // 1
	}
	
	// Update is called once per frame
	void Update () {

        // look at cube on left
        if (tutorialStage == 1 && one)
        {
            one = false;
            StartCoroutine(StageOne()); // 2
        }

        if(leftCube.GetComponent<Renderer>().material.color == Color.green && two)
        {
            two = false;
            ToggleActive(promptObj);
            ToggleActive(imageObj);
            SetTextDisplay(prompt_2);
            three = true;
        }

        // look at cube on right
        if (three)
        {
            three = false;
            StartCoroutine(StageTwo());
        }

        if (rightCube.GetComponent<Renderer>().material.color == Color.green && four)
        {
            four = false;
            ToggleActive(promptObj);
            ToggleActive(imageObj);
            SetTextDisplay(prompt_3);
            five = true;
        }

        // move to front circle
        if (five)
        {
            five = false;
            StartCoroutine(StageThree());
        }

        if (six)
        {
            six = false;
            StartCoroutine(StageFour());
        }

        if (seven)
        {
            seven = false;
            ToggleActive(imageObj);
            ToggleActive(promptObj);
            SetTextDisplay(prompt_4);
            eight = true;
        }

        // move to back circle
        if (eight)
        {
            eight = false;
            StartCoroutine(StageFive());
        }

        if (nine)
        {
            nine = false;
            StartCoroutine(StageSix());
        }

        // interact with an object
        if(ten)
        {
            ten = false;
            StartCoroutine(StageSeven());
        }

        if (eleven && button.GetComponentInChildren<Button>().pushed)
        {
            if (basic)
            {
                eleven = false;
                ToggleActive(promptObj);
                SetTextDisplay(prompt_6);
                twelve = true;
            }
            else
            {
                // AV STUFF
                eleven = false;
                ToggleActive(promptObj);
                SetTextDisplay(prompt_7);
                ToggleActive(leftViewport);
                ToggleActive(rightViewport);
                ToggleActive(leapSpace);
                ToggleActive(webCamScreen);
                twelve = true;
            }
        }

        if (twelve)
        {
            if (Input.GetButtonDown("A Button"))
            {
                Application.Quit();
            }
        }
	}

    // Activate/Deactivate Gameobject
    void ToggleActive(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }

    // Change content of text display
    void SetTextDisplay(string str)
    {
        textPrompt.text = str;
    }

    // Change content of image display
    void SetImageDisplay(Sprite sprite)
    {
        image.sprite = sprite;
    }

    // look tutorial
    void LookTutorial()
    {
        ToggleActive(hud);
        SetTextDisplay(prompt_0);
        SetImageDisplay(buttonA);

        // when A is pressed, show next message
        StartCoroutine(WaitForInputMessage("A Button", prompt_1));

    }

    // coroutine to wait for input and set correct message
    IEnumerator WaitForInputMessage(string inputToWaitFor, string nextMessage)
    {
        while (true)
        {
            if(Input.GetButtonDown(inputToWaitFor))
            {
                SetTextDisplay(nextMessage);
                tutorialStage++;
                yield break;
            }
            yield return null;
        }
    }

    // coroutine to wait for input and toggle active object
    IEnumerator WaitForInputToggle(string inputToWaitFor, GameObject obj)
    {
        while (true)
        {
            if(Input.GetButtonDown(inputToWaitFor))
            {
                tutorialStage++;
                ToggleActive(obj);
                yield break;
            }
            yield return null;
        }
    }



    // new system
    IEnumerator StageOne()
    {
        while (true)
        {
            if(Input.GetButtonDown("A Button"))
            {
                ToggleActive(imageObj);
                ToggleActive(leftCube);
                ToggleActive(promptObj);
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageTwo()
    {
        while (true)
        {
            if(Input.GetButtonDown("A Button"))
            {
                ToggleActive(imageObj);
                ToggleActive(leftCube);
                ToggleActive(rightCube);
                ToggleActive(promptObj);
                four = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageThree()
    {
        while (true)
        {
            if(Input.GetButtonDown("A Button"))
            {
                ToggleActive(imageObj);
                ToggleActive(rightCube);
                ToggleActive(promptObj);
                ToggleActive(frontCircle);
                six = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageFour()
    {
        while (true)
        {
            if(frontCircle.GetComponent<Collideable>().triggered)
            {
                seven = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageFive()
    {
        while (true)
        {
            if(Input.GetButtonDown("A Button"))
            {
                ToggleActive(imageObj);
                ToggleActive(promptObj);
                ToggleActive(frontCircle);
                ToggleActive(backCircle);
                nine = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageSix()
    {
        while (true)
        {
            if(backCircle.GetComponent<Collideable>().triggered)
            {
                ToggleActive(imageObj);
                ToggleActive(promptObj);
                SetTextDisplay(prompt_5);
                ten = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator StageSeven()
    {
        while (true)
        {
            if(Input.GetButtonDown("A Button"))
            {
                ToggleActive(promptObj);
                ToggleActive(imageObj);
                ToggleActive(button);
                ToggleActive(backCircle);
                eleven = true;
                yield break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// // AV PART OF TUTORIAL
    /// </summary>

    // activate AV system
    // bla bla method here to do last part of tutorial (just a diagram 
    // of what to do with hands and let them do whatever until they feel comfortable)

    /// <summary>
    /// //
    /// </summary>
}