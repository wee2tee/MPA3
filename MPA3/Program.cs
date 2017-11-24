using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPA3
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Arguments not specified completely!");
                Console.WriteLine("");
                Console.WriteLine("Press any key to close this window");
                Console.ReadKey();
                return;
            }
            else
            {
                //Console.WriteLine("");
                //Console.WriteLine(args[0]);
                //Console.ReadKey();
                try
                {
                    System.Diagnostics.Process.Start("java.exe", @"-jar GenXML.jar d:\genxml\json_input.json d:\express\expressi\etaxinvoice\xml\EtDa-invoice.xml");
                    Console.WriteLine("");
                    Console.WriteLine("Success");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
