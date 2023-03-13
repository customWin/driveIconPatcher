using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace driveIconPatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("      _      _           _____                _____      _       _               \r\n" +
                              "     | |    (_)         |_   _|              |  __ \\    | |     | |              \r\n" +
                              "   __| |_ __ ___   _____  | |  ___ ___  _ __ | |__) |_ _| |_ ___| |__   ___ _ __ \r\n" +
                              "  / _` | '__| \\ \\ / / _ \\ | | / __/ _ \\| '_ \\|  ___/ _` | __/ __| '_ \\ / _ \\ '__|\r\n" +
                              " | (_| | |  | |\\ V /  __/_| || (_| (_) | | | | |  | (_| | || (__| | | |  __/ |   \r\n" +
                              "  \\__,_|_|  |_| \\_/ \\___|_____\\___\\___/|_| |_|_|   \\__,_|\\__\\___|_| |_|\\___|_|   \r\n");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Patch your drive icons in a easy way!                              by jbcarreon123");
            Console.WriteLine("          Licensed under MIT License. Comes with ABSOLUTELY NO WARRANTY!");
            Console.WriteLine("");


            Console.WriteLine($"Patching {args[0]}...");
            Console.WriteLine($"Specified icon: {args[1]}");
            try
            {
                var driveicons = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Microsoft", true)
                    .OpenSubKey("Windows", true).OpenSubKey("CurrentVersion", true).OpenSubKey("Explorer", true).OpenSubKey("DriveIcons", true);

                var drive = driveicons.CreateSubKey(args[0].Remove(1));
                var deficon = drive.CreateSubKey("DefaultIcon");

                deficon.SetValue("", $"\"{args[1]}\"");

                Console.WriteLine($"Successfully patched {args[0]} with {args[1]}!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"[ERROR] {e}");
            }


        }
    }
}
