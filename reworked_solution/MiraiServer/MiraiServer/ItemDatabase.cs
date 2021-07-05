using System;
using System.Collections.Generic;
using System.Text;

namespace MiraiServer
{
    class ItemDatabase
    {
        // temporary !
        static Item testHair = new Item(1, "Test Hair", 0, "blonde curly hair..", "testHair");
        static Item testOutfit = new Item(2, "Test Outfit", 3, "green curly hair..", "testOutfit");
        static Item testShoes = new Item(3, "Test Shoes", 5, "a squid on your head!", "testShoes");
        static Item testFaceAccessory = new Item(4, "Test Face Accessory", 9, "a squid on your head!", "testFaceAcc");
        static Item testBodyAccessory = new Item(5, "Test Body Accessory", 11, "a squid on your head!", "testBodyAcc");
        static Item butterflyHair = new Item(6, "Butterfly Hair", 0, "", "butterflyHair");
        static Item butterflyTop = new Item(7, "Butterfly Top", 1, "", "butterflyTop");
        static Item butterflyBottom = new Item(8, "Butterfly Bottom", 2, "", "butterflyBottom");
        static Item butterflyShoes = new Item(9, "Butterfly Shoes", 5, "", "butterflyShoes");

        static Item scarletBraids = new Item(10, "Scarlet Braids", 0, "", "scarletBraids");
        static Item jiangShiStreetTankTopMasc = new Item(11, "Jiang Shi Street Tank Top Masc.", 1, "", "jiangShiStreetTankTopMasc");
        static Item jiangShiStreetBottomMasc = new Item(12, "Scarlet Braids", 2, "", "jiangShiStreetBottomMasc");
        static Item ornamentalGoldEarrings = new Item(13, "Scarlet Braids", 8, "", "ornamentalGoldEarrings");


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
            ornamentalGoldEarrings,
        };


    }
}
