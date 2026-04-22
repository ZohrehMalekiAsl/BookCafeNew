using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Services
{
    public  class Animal
    {
        public string Category { get; set; }
        public virtual void Eat()
        {
            Console.WriteLine("EAT");
            Console.ReadKey();
        }

        public virtual void Speak(string speak)
        {
            Console.WriteLine("SPEAK"+speak);
            Console.ReadKey();
        }

        public virtual void SpeakWithoutChild(string speak)
        {
            Console.WriteLine("SPEAK WithOut Child" + speak);
            Console.ReadKey();
        }
        public void Walk()
        {
            Console.WriteLine("WALK");
            Console.ReadKey();
        }
        public void Repeat()
        { Console.WriteLine("REPATE");
            Console.ReadKey();
        }
    }
}
