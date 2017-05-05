using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {
    [SerializeField] Inventory playerInventory;
    [SerializeField] MessageController messageController;
    [SerializeField] GameObject lionKey;
    [SerializeField] GameObject dragonIdol;
    [SerializeField] GameObject door;
    [SerializeField] AudioClip wrong;

    [SerializeField] GameObject rune1;
    [SerializeField] GameObject rune2;
    [SerializeField] GameObject rune3;
    [SerializeField] GameObject rune4;
    [SerializeField] GameObject rune5;
    [SerializeField] GameObject rune6;

    GameObject[] runes;
    GameObject[] correctOrder;
    public List<GameObject> currentAttempt = new List<GameObject>();

    bool messageSent = false;
    public bool solved = false;
    int numRunes;

    void Start()
    {
        runes = new GameObject[] { rune1, rune2, rune3, rune4, rune5, rune6 };
        numRunes = runes.Length;
        correctOrder = new GameObject[] { rune1, rune5, rune6, rune4, rune2, rune3 };
    }

    void Update()
    {
        if (playerInventory.HasItem(dragonIdol) && !messageSent)
        {
            messageSent = true;
            messageController.SetMessage(messageController.message6); 
        }

        if(!solved)
        {
            solved = CheckSolution();
            if (solved)
                door.GetComponent<AudioSource>().Play();
        }

        if(solved && door.transform.eulerAngles.y < 359.0f)
        {
            door.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character" && playerInventory.HasItem(lionKey))
        {
            messageController.SetMessage(messageController.message4);
        }
    }

    bool CheckSolution()
    {
        if(currentAttempt.Count == 6)
        {
            for(int i=0; i < currentAttempt.Count - 1; i++)
            {
                if(currentAttempt[i] != correctOrder[i])
                {
                    DeactivateAll();
                    ClearCurrentAttempt();
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    public void DeactivateAll()
    {
        for(int i=0; i<runes.Length; i++)
        {
            runes[i].GetComponent<Rune>().activated = false;
            runes[i].GetComponent<AudioSource>().PlayOneShot(wrong);
        }
    }

    public void ClearCurrentAttempt()
    {
        currentAttempt.Clear();
    }

    bool NoneActive()
    {
        for(int i=0; runes[i]; i++)
        {
            if (runes[i].GetComponent<Rune>().activated == true)
            {
                return false;
            }
        }
        return true;
    }
}