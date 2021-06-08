using System;
using System.Collections.Generic;
using System.Text;

namespace MiraiServer
{
    class ItemDatabase
    {

        static Item testBlondeCurlyHair = new Item(1, "Blonde Curls", 0, "blonde curly hair..", "testBlondeCurylyHair");
        static Item testGreenCurlyHair = new Item(2, "Green Curls", 0, "green curly hair..", "testGreenCurlyHair");
        static Item redSquidHair = new Item(3, "Red Squid Head", 0, "a squid on your head!", "redSquidHair1");

        public static List<Item> items = new List<Item>()
        {
            testBlondeCurlyHair,
            testGreenCurlyHair,
            redSquidHair,
        };


    }
}
