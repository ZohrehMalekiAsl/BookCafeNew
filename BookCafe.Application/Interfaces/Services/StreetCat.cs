using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Services
{
    public class StreetCat: Cat
    {
        public override void Speak(string s)
        {
            Console.WriteLine("speak street");
            Console.ReadKey();
        }
        //public override void Read(string book)
        //{
        //    Console.WriteLine("read street");
        //    Console.ReadKey();
        //}
    }
}
