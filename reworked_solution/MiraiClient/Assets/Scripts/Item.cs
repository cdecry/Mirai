using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public int id;
    public string name;
    public int type;
    public string description;
    public string reference;

    public Item(int itemID, string itemName, int itemType, string itemDescription, string itemReference)
    {
        id = itemID;
        name = itemName;
        type = itemType;
        description = itemDescription;
        reference = itemReference;
    }

}
