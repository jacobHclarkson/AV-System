using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    [SerializeField] GameObject gate;
    [SerializeField] ProximityChecker proxChecker;

    public bool on = false;
    public bool standing = false;

    public float gateMax;
    public float gateMin = 0.02f;
    public bool solved = false;

    public Vector3 gateStartPosition;
    private Vector3 buttonStartPosition;



    void Start()
    {
        gateStartPosition = gate.transform.position;
        buttonStartPosition = transform.position;
    }
	
	void Update () {
        if (!solved)
        {
            standing = CheckForPlayer();
            if (on || standing)
            {
                if (transform.position.y > buttonStartPosition.y - 0.06)
                {
                    transform.Translate(Vector3.down * Time.deltaTime);
                }

                if(gate.transform.position.y < gateStartPosition.y + 3.9)
                {
                    gate.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                }
            }

            if(!on && !standing)
            {
                if (transform.position.y < buttonStartPosition.y)
                {
                    transform.Translate(Vector3.up * Time.deltaTime);
                }

                if(gate.transform.position.y > gateStartPosition.y)
                {
                    gate.transform.Translate(Vector3.down * Time.deltaTime * 5, Space.World);
                }
            }
        }
	}

    bool CheckForPlayer()
    {
        if (proxChecker.inProximity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        on = true;
    }

    void OnTriggerExit(Collider col)
    {
        on = false;
    }
}
