using UnityEngine;
using System.Collections;

public class Collideable : MonoBehaviour {

    public Collider player;
    public bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            triggered = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
