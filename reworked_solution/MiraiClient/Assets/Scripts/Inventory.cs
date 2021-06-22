using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static List<Item> items = new List<Item>();

    public static void AddItem(int _itemID) // call this when receive msg from server!
    {
        var requestedItem = ItemDatabase.items.FirstOrDefault(item => item.id == _itemID);
        if (requestedItem != null)
        {
            items.Add(requestedItem);
            UserInterface.AddToInventory(requestedItem.reference, requestedItem.type);
            Debug.Log("Added a " + requestedItem.name + " to this inventory, refernce was " + requestedItem.reference + " and type " + requestedItem.type);
        }
    }


    public static void ChangeClothes(int _playerID, List<int> _items) // should be int _hair int _top etc...
    {

        Debug.Log("ChangeClothes(): itemid is " + _items[0]);
        for (int i = 0; i < _items.Count; i++)
        {
            var requestedItem = ItemDatabase.items.FirstOrDefault(item => item.id == _items[i]);
            if (requestedItem != null)
            {
                UserInterface.ChangeClothes(_playerID, requestedItem.reference, requestedItem.type);
                Debug.Log("ChangeClothes(): ref is " + requestedItem.reference);
            }
        }
        
    }

    
}
