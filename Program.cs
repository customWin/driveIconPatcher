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
        static void Main(string[] a)
        {
            var args = a.ToList();
            args.Remove(a[0]);
            var arg0 = a[0];

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


            Console.WriteLine($"Patching {arg0}...");
            Console.WriteLine($"Specified icon: {String.Join("", args)}");
            try
            {
                var driveicons = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Microsoft", true)
                    .OpenSubKey("Windows", true).OpenSubKey("CurrentVersion", true).OpenSubKey("Explorer", true).OpenSubKey("DriveIcons", true);

                var drive = driveicons.CreateSubKey(arg0.Remove(1));
                var deficon = drive.CreateSubKey("DefaultIcon");

                deficon.SetValue("", $"\"{String.Join(" ", args)}\"");

                Console.WriteLine($"Successfully patched {arg0} with {String.Join("", args)}!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"[ERROR] {e}");
            }


        }
    }
}
