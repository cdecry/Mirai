using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static List<Item> items = new List<Item>();

    public static void AddItem(int _itemID)
    {
        var requestedItem = ItemDatabase.items.FirstOrDefault(item => item.id == _itemID);
        if (requestedItem != null)
        {
            items.Add(requestedItem);
            UserInterface.AddToInventory(requestedItem.reference, requestedItem.type);
            Debug.Log("Added a " + requestedItem.name + " to this inventory, refernce was " + requestedItem.reference);
        }
    }

    
}
