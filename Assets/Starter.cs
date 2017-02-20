using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Starter : MonoBehaviour {

    public float startInSeconds = 5.0f;

    public GameObject typingHud;

    public Text startText; // display for start text
    bool started = false;
    float timeRemaining = 5.0f;

    bool go = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
        }
        if (started)
        {
            UpdateTime();
        }

        if (go)
        {
            // activate all the other objects
            typingHud.SetActive(true);

            // deactivate starter text object
            startText.text = "";
        }
	}

    // start timer
    void UpdateTime()
    {
            timeRemaining -= Time.deltaTime;
            startText.text = Mathf.Round(timeRemaining).ToString();
            if(timeRemaining <= 0)
            {
                go = true;
            }
    }
}
