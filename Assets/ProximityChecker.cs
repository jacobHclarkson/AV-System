using UnityEngine;
using System.Collections;

public class ProximityChecker : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] float requiredDistance;

    public bool inProximity = false;
    float distance;

	void Update () {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= requiredDistance)
        {
            inProximity = true;
        }
        else
        {
            inProximity = false;
        }
	}
}
