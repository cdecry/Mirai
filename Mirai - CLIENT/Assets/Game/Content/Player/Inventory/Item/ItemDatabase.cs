using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDatabase : MonoBehaviour
{
    private static ItemDatabase _instance;
    public static ItemDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.Exception();
            }
            return _instance;
        }
    }

    public List<Item> items;

    private void Awake()
    {
        _instance = this;
        GenerateItems();
    }

    private void GenerateItems()
    {
        var squareHat = new Item("Square Hat", 0, "headAccesssory", "It's square that you wear on your head...", false, true);

        items.Add(squareHat);
    }

}
