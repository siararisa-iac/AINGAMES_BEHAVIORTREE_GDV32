using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> inventory;

    public bool ContainsItem(string itemName)
    {
        return inventory.Contains(itemName);
    }
}
