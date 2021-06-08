using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiraiServer
{
    class Inventory
    {

        public static List<Item> items = new List<Item>();
        
        public void AddItem(int _itemID)
        {
            var requestedItem = ItemDatabase.items.FirstOrDefault(item => item.id == _itemID);
            if (requestedItem != null)
            {
                items.Add(requestedItem);
                Console.WriteLine("Added a " + requestedItem.name + " to this inventory.");
            }
        }
        

    }
}
