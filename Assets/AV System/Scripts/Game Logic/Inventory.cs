using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> items;

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    public bool HasItem(GameObject item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
