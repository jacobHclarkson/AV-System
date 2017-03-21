using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

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

    // look targets
    public GameObject leftCube;
    public GameObject rightCube;

    // move targets

    // messages
    private string prompt_0 = "Hello! Welcome to the tutorial stage. In this tutorial, you will learn how to move and interact in VR. Press the 'A' button on your controller to continue.";
    private string prompt_1 = "To look around, turn your head. Look at the red cube to your left until it turns green. First, dismiss this message by pressing 'A'.";
    private string prompt_2 = "Excellent! Now look at the red cube on your right until it turns green. First, dismiss this message by pressing 'A'.";
    private string prompt_3 = "Great. Now lets try moving around.";
    private string prompt_4 = "";
    private string prompt_5 = "";
    private string prompt_6 = "";

    // bools and things to control coroutines
    private int tutorialStage = 0;
    bool one = true;
    bool two = true;
    bool three = false;
    bool four = false;

	// Use this for initialization
	void Start () {
        ToggleActive(hud);
        SetTextDisplay(prompt_0);
        SetImageDisplay(buttonA);

        // first message transition
        StartCoroutine(WaitForInputMessage("Jump", prompt_1)); // 1
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
            SetTextDisplay(prompt_3);
        }

        // move to circle
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
        StartCoroutine(WaitForInputMessage("Jump", prompt_1)); // TODO change jump to A

        // dismiss message
        // activate cube
        // next message
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
            if(Input.GetButtonDown("Jump"))
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
            if(Input.GetButtonDown("Jump"))
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
}
