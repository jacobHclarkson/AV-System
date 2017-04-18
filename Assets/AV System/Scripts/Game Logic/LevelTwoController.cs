using UnityEngine;
using System.Collections;

public class LevelTwoController : MonoBehaviour {
    [SerializeField] GameObject gate;
    [SerializeField] TableColliderCheck horseTable;
    [SerializeField] TableColliderCheck dragonTable;
    [SerializeField] TableColliderCheck lionTable;

    bool solved = false;
	
	void Update () {
        if (!solved)
        {
            CheckSolution();
        }

        if(solved && gate.transform.position.y < 4.0f)
        {
            gate.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
	}

    void CheckSolution()
    {
        if(horseTable.objectPlaced && dragonTable.objectPlaced && lionTable.objectPlaced)
        {
            solved = true;
        }
    }
}
