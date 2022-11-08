using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class Professor : User
    {
        public string Dept { get; set; }
        public Professor(string name, string password, string address,
            string phoneNumber, string dept) : base(name, password, address, phoneNumber)
        {
            if (Program.professors.Count > 0)
            {
                Id = Program.professors.Count + 1;
            }
            else Id = 1;
            Dept = dept;
        }
        public Professor() 
        {
            if (Program.professors.Count > 0)
            {
                Id = Program.professors.Count + 1;
            }
            else Id = 1;
        }
        public override void Register()
        {
            base.Register();
            Console.Write("Enter a department: ");
            string dept = Console.ReadLine().Trim();
            this.Dept = dept;
        }
        public override void ViewProfile(int id)
        {
            foreach (var professor in Program.professors)
            {
                if (professor.Id == id)
                {
                    Console.WriteLine($"ID: {professor.Id}");
                    Console.WriteLine($"Your name: {professor.Name}");
                    Console.WriteLine($"Your address: {professor.Address}");
                    Console.WriteLine($"Your phone number: {professor.PhoneNumber}");
                    Console.WriteLine($"Your department: {professor.Dept}");
                }
            }
        }
    }
}
