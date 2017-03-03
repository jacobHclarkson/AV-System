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

    // look targets
    public GameObject greenLookTarget;

    // move targets

	// Use this for initialization
	void Start () {
        ToggleActive(hud);
        SetTextDisplay("It's working!");
        ToggleActive(greenLookTarget);
        SetImageDisplay(allButtons);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleActive(reticle);
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
    void SetImageDisplay(Sprite tex)
    {
        image.sprite = allButtons;
    }
}
