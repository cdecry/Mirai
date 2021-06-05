using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public string type;
    public string description;
    public Sprite icon;
    public bool members;
    public bool tradeable;

    public Item(string itemName, int itemID, string itemType, string itemDescription, bool membersOnly, bool isTradeable)
    {
        this.name = itemName;
        this.id = itemID;
        this.type = itemType;
        this.description = itemDescription;
        this.icon = null;
        this.members = membersOnly;
        this.tradeable = isTradeable;
    }

}
