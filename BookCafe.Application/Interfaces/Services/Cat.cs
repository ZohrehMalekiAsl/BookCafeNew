using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Services
{
    public class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("eat");
            Console.ReadKey();
        }
        public new void  Walk()
        {
            Console.WriteLine("walk");
            Console.ReadKey();
        }
        public override void Speak(string s)
        {
            if (s == "l")
            {
                Console.WriteLine("speak");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine(s);
                Console.ReadKey();
            };
        }
        public  void Read(string book)
        {
            Console.WriteLine("read");
            Console.ReadKey();
        }
        public void Repeat()
        {
            Console.WriteLine("repeat");
            Console.ReadKey();
        }
    }
}
