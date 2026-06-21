using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    HashSet<string> items = new HashSet<string>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log("Added: " + item);
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }
}
