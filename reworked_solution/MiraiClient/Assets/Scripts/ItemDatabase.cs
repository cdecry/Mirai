using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    /*
     * 0 - Hair
     * 1 - Top
     * 2 - Bottom
     * 3 - Outfit
     * 4 - Shoes
     * 5 - Board
     * 6 - Head Accesory
     * 7 - Face Accessory
     * 8 - Body Accessory
     * 9 - Face
     * 10 - Base
     */


    static Item testHair = new Item(1, "Test Hair", 0, "blonde curly hair..", "testHair");
    static Item testOutfit = new Item(2, "Test Outfit", 3, "green curly hair..", "testOutfit");
    static Item testShoes = new Item(3, "Test Shoes", 4, "a squid on your head!", "testShoes");
    static Item testFaceAccessory = new Item(4, "Test Face Accessory", 7, "a squid on your head!", "testFaceAcc");
    static Item testBodyAccessory = new Item(5, "Test Body Accessory", 8, "a squid on your head!", "testBodyAcc");
    static Item butterflyHair = new Item(6, "Butterfly Hair", 0, "", "butterflyHair");
    static Item butterflyTop = new Item(7, "Butterfly Top", 1, "", "butterflyTop");
    static Item butterflyBottom = new Item(8, "Butterfly Bottom", 2, "", "butterflyBottom");
    static Item butterflyShoes = new Item(9, "Butterfly Shoes", 4, "", "butterflyShoes");


    public static List<Item> items = new List<Item>()
        {
            testHair,
            testOutfit,
            testShoes,
            testFaceAccessory,
            testBodyAccessory,
            butterflyHair,
            butterflyTop,
            butterflyBottom,
            butterflyShoes,
        };
}
