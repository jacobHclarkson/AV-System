using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

    [SerializeField] private Collideable col;

	// Update is called once per frame
	void Update () {
        if (col.triggered)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	}
}
