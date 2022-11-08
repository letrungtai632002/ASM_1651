using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class Manager : User
    {
        public Manager(string name, string password) :base(name, password)
        {
            if (Program.managers.Count > 0)
            {
                int setID = Program.managers[Program.managers.Count - 1].Id;
                Id = setID + 1;
            }
            else Id = 1;
            Name = name;
            Password = password;
        }
        public override void ViewMenu()
        {
            Console.WriteLine("-------------------Wellcome to library-------------------");
            Console.WriteLine("|Enter option from 1 to 10:                              |");
            Console.WriteLine("|  1: Search Book                                        |");
            Console.WriteLine("|  2: View all books                                     |");
            Console.WriteLine("|  3: View all order                                     |");
            Console.WriteLine("|  4: View all payment                                   |");
            Console.WriteLine("|  5: View all student                                   |");
            Console.WriteLine("|  6: View all professor                                 |");
            Console.WriteLine("|  7: Add book                                           |");
            Console.WriteLine("|  8: Delete book                                        |");
            Console.WriteLine("|  9: Update book                                        |");
            Console.WriteLine("| 10: Logout                                             |");
            Console.WriteLine("---------------------------------------------------------");
        }
        public void ViewAllOrder()
        {
            if (Program.orderDetails.Count == 0) Console.WriteLine("No order in list");
            else
                foreach (var order in Program.orderDetails)
                Console.WriteLine($"{order.ToString()}");
        }
        public void ViewAllPayment()
        {
            if (Program.payments.Count == 0) Console.WriteLine("No payment in list");
            else
            foreach (var payment in Program.payments)
            {
                Console.WriteLine(payment.ToString());               
            }
        }
        public void ViewAllStudent()
        {
            if (Program.students.Count == 0) Console.WriteLine("No student in list");
            else
                foreach (var student in Program.students)
                student.ViewProfile(student.Id);
        }
        public void ViewAllProfessor()
        {
            if (Program.professors.Count == 0) Console.WriteLine("No professor in list");
            else
            foreach (var professor in Program.professors)
                professor.ViewProfile(professor.Id);
        }
        public void AddBook()
        {
            Console.Write("Enter the book's name: ");
            var name = Console.ReadLine().Trim();
            Console.Write("Enter the book's author: ");
            var author = Console.ReadLine().Trim();
            Console.Write("Enter the book's year of publish: ");
            var year = int.Parse(Console.ReadLine().Trim());
            Console.Write("Enter the book's quantity: ");
            var quantity = int.Parse(Console.ReadLine().Trim());
            Console.Write("Enter the book's price: ");
            var price = decimal.Parse(Console.ReadLine().Trim());
            Program.books.Add(new Book(name, author, year, quantity, price));
        }
        public void DeleteBook()
        {
            Console.Write("Enter the book's ID to delete: ");
            var id = int.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < Program.books.Count; i++)
                if (Program.books[i].ID == id) Program.books.Remove(Program.books[i]);
        }
        public void UpdateBook()
        {
            Console.Write("Enter the book's ID to update: ");
            var id = int.Parse(Console.ReadLine().Trim());
            for (var i = 0; i < Program.books.Count; i++)
                if (Program.books[i].ID == id)
                {
                    Console.Write("Enter the book's name: ");
                    var name = Console.ReadLine().Trim();
                    Program.books[i].Name = name;
                    Console.Write("Enter the book's author: ");
                    var author = Console.ReadLine().Trim();
                    Program.books[i].Author = author;
                    Console.Write("Enter the book's year of publish: ");
                    var year = int.Parse(Console.ReadLine().Trim());
                    Program.books[i].YearOfPublish = year;
                    Console.Write("Enter the book's quantity: ");
                    var quantity = int.Parse(Console.ReadLine().Trim());
                    Program.books[i].Quantity = quantity;
                    Console.Write("Enter the book's price: ");
                    var price = decimal.Parse(Console.ReadLine().Trim());
                    Program.books[i].Price = price;
                }
        }
    }
}
