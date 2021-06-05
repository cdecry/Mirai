using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class Inventory : MonoSingleton<Inventory>
{
    protected override void Init()
    {
        base.Init();
        Debug.Log("inbent owrk");

    }

    public List<Item> items = new List<Item>(10);


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You found a Square Hat!");
            AddItem(0);   
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("removing square hat :c");
            RemoveItem(0);
        }
    }

    public void AddItem(int itemID)
    {
        //check if item exists in itemDB
        //then add it

        var itemRequested = ItemDatabase.Instance.items.FirstOrDefault(Item => Item.id == itemID);

        if (itemRequested != null)
        {
            Inventory.Instance.items.Add(itemRequested);
        }
    }

    public void RemoveItem(int itemID)
    {
        //check if item exists in itemDB and user invent
        //remove it
        var itemRequested = ItemDatabase.Instance.items.FirstOrDefault(Item => Item.id == itemID);

        if (itemRequested != null)
        {
            //check if item is in player invent
            //remove

            var hasItem = items.Any(item => item.id == itemID);
            if (hasItem)
            {
                Inventory.Instance.items.Remove(itemRequested);
            }
            else
            {
                Debug.Log("homie u dont got that item");
            }
        }

    }
}
