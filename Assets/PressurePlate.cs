using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    [SerializeField] GameObject gate;
    [SerializeField] ProximityChecker proxChecker;

    public bool on = false;
    public bool standing = false;
	
	void Update () {
        standing = CheckForPlayer();
        if (on || standing)
        {
            if (transform.position.y > 0.02f)
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }

            if(gate.transform.position.y < 4.0f)
            {
                gate.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            }
        }

        if(!on && !standing)
        {
            if (transform.position.y < 0.1f)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }

            if(gate.transform.position.y > 0f)
            {
                gate.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
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
