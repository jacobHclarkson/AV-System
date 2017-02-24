using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

// this script will control when the typing container hides/shows to the player.

public class TypingContainerController : MonoBehaviour {

    [SerializeField] GameObject typingContainer;
    public InputField inputField;

    // whether or not to show the typing box
    bool show = true;

    // string entered by user
    string finalInputString = "";
    string rawInputString = "";

    // stuff for timing
    System.DateTime startTime;
    System.TimeSpan timeElapsed;

    // stuff for displaying words/recording input
    string currentPrompt;
    string prescribedText = "";
    string[] wordlist;
    public TextAsset textAsset;
    public int wordsPerLine = 15;
    public Text prompt;

    // time the test should run for
    public float timeRemaining = 60.0f;

    // time to first keypress
    bool firstKeyPressed = false;
    float timeToFirstKeyPress = 0.0f;

    void Start()
    {
        //ToggleShow();
        // simulate mouse click in input field (get focus)
        inputField = GetComponentInChildren<InputField>();
        inputField.Select();

        // note start time
        startTime = System.DateTime.Now;

        // read words from file
        ReadWords();
        currentPrompt = GenerateWords();
        prompt.text = currentPrompt;
    }

    void Update()
    {
        if (!firstKeyPressed)
        {
            if(rawInputString != "")
            {
                firstKeyPressed = true;
            }
        }


        CaptureRawInput();

        // timer
        if (!firstKeyPressed)
        {
            timeToFirstKeyPress += Time.deltaTime;
        }
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <=0)
        {
            // grab whatever the user has got so far and exit
            finalInputString += " " + inputField.text;

            // write stuff to file
            WriteToFile();

            Debug.Log("Exiting");
            Application.Quit();
        }

	    if (Input.GetKeyDown(KeyCode.Return)){
            SavePrompt();

            // record transcribed text
            finalInputString += " " + inputField.text;

            // add space to raw input
            rawInputString += " ";

            currentPrompt = GenerateWords();
            prompt.text = currentPrompt;
            inputField.text = "";
            inputField.ActivateInputField();
            inputField.Select();

            Debug.Log(rawInputString);
            Debug.Log(finalInputString);

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


    // Save prescribed text
    public void SavePrompt()
    {
        prescribedText += prompt.text;
    }

    // getter for recorded prescribed text
    public string GetPrescribedText()
    {
        return prescribedText;
    }

    // read words from file
    void ReadWords()
    {
        string wordsFromFile = textAsset.text;
        wordlist = wordsFromFile.Split(' ');
    }

    // generate the next line of words
    string GenerateWords()
    {
        string nextPrompt = "";
        for(int i=0; i<wordsPerLine; i++)
        {
            int idx = Random.Range(0, wordlist.Length);
            nextPrompt = nextPrompt + wordlist[idx] + " ";
        }
        return nextPrompt;
    }

    // write data to file
    void WriteToFile()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "data.txt");
        sw.WriteLine(finalInputString);
        sw.WriteLine(rawInputString);
        sw.WriteLine(timeToFirstKeyPress);
        sw.Close();
    }
}
