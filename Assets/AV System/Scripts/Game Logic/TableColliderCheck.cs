using UnityEngine;
using System.Collections;

public class TableColliderCheck : MonoBehaviour {
    [SerializeField] GameObject keyObject;
    public bool objectPlaced = false;

    void OnTriggerEnter(Collider tableTriggerCollider)
    {
        if (tableTriggerCollider.GetComponent<Collider>().name == keyObject.name)
        {
            objectPlaced = true;
        }
    }
}
