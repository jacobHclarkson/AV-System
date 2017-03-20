using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // HUD canvas
    public GameObject hud;

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
    public GameObject greenLookTarget;

    // move targets

    // messages
    private string prompt_0 = "Hello! Welcome to the tutorial stage. In this tutorial, you will learn how to move and interact in VR. Press the 'A' button on your controller to continue.";
    private string prompt_1 = "";
    private string prompt_2 = "";
    private string prompt_3 = "";
    private string prompt_4 = "";
    private string prompt_5 = "";
    private string prompt_6 = "";

	// Use this for initialization
	void Start () {
        LookTutorial();
        //SetTextDisplay("It's working!");
        //ToggleActive(greenLookTarget);
        //SetImageDisplay(allButtons);
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    ToggleActive(reticle);
        //}
        if (Input.GetButtonDown("A Button"))
        {
            Debug.Log("a button pressed");

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
        if (Input.GetButtonDown("A Button"))
        {
            SetTextDisplay(prompt_2);
        }
    }
}
