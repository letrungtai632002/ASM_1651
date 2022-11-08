using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class Student : User
    {
        public string ClassName { get; set; }
        public Student(string name, string password, string address,
            string phoneNumber, string className ) : base(name, password, address, phoneNumber)
        {
            if (Program.students.Count >= 0)
            {
               Id = Program.students.Count+1;
            }
            else Id = 1;
            ClassName = className;
        }
        public Student()  
        {
            if (Program.students.Count >= 0)
            {
                Id = Program.students.Count + 1;
            }
            else Id = 1;
        }

        public override void Register()
        {
            base.Register();
            Console.Write("Enter a class name: ");
            string className = Console.ReadLine().Trim();
            this.ClassName = className;
            
        }
        public override void ViewProfile(int id)
        {
            foreach (var student in Program.students)
            {
                if (student.Id == id)
                {
                    Console.WriteLine($"ID: {student.Id}");
                    Console.WriteLine($"Your name: {student.Name}");
                    Console.WriteLine($"Your address: {student.Address}");
                    Console.WriteLine($"Your phone number: {student.PhoneNumber}");
                    Console.WriteLine($"Your class: {student.ClassName}");
                }
            }
        }
    }
}
