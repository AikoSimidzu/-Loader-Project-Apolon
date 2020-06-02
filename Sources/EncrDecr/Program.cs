using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrDecr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your domain with Http/s\n");
            string Domain = Console.ReadLine();            
            Console.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Domain}/gate.php?")));
            Console.ReadKey();
        }
    }
}
