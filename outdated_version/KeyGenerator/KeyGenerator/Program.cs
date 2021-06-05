using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace KeyGenerator
{
    class Program
    {
        public static List<string> keys = new List<string>();
        public static string newKey = "";
        public static int keyLength = 8;
        public static int amountOfKeys = 10;
        public const string DATA_URL = "http://localhost:81/keygenerator.php";


        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*** MIRAI ALPHA KEY GENERATOR ***\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Initializing Key Generator...\n");
            keys.Clear();

            Console.WriteLine("Enter the amount of keys to generate.");
            amountOfKeys = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGenerating " + amountOfKeys + " Unique Alpha Keys...\n");

            for (int i = 0; i < amountOfKeys; i++)
            {
                for (int j = 0; j < keyLength; j++)
                {
                    Random random = new Random();
                    newKey += random.Next(0, 10).ToString();
                }

                keys.Add(newKey);
                newKey = "";
            }

            var freshKeys = keys.GroupBy(k => k).Select(k => k.FirstOrDefault());

            WebClient client = new WebClient();



            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var key in freshKeys)
            {
                Console.WriteLine("GAME-KEY: " + key);
                NameValueCollection form = new NameValueCollection();
                form.Add("key", key);
                byte[] responseData = client.UploadValues(DATA_URL, form);

            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nKeys Successfully Added.");

            Console.ReadKey();
        }
    }
}
