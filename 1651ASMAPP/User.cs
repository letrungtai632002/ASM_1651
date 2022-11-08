using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1651ASMAPP
{
    internal class User : ISearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public User(string name, string password, string address, string phoneNumber)
        {
            Name = name;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public User() { }

        public User(string name, string password) 
        {
            Name = name;
            Password = password;
        }
        public void SearchBook(string nameBook)
        {          
            var check = false;
            foreach (var book in Program.books)
            {
                if (nameBook.Equals(book.Name))
                {
                    Console.WriteLine($"{book.DisplayBook()}");
                    check = true;
                }    
                else 
                if (book.Name.Contains(nameBook))
                {
                    Console.WriteLine($"{book.DisplayBook()}");
                    check = true;
                }   
            }
            if (!check) Console.WriteLine("Not exist this book's name");
        }
        public virtual void ViewMenu()
        {
            Console.WriteLine("-------------------Wellcome to library-------------------");
            Console.WriteLine("|Enter option from 1 to 8:                              |");
            Console.WriteLine("| 1: View your profile                                  |");
            Console.WriteLine("| 2: Search Book                                        |");
            Console.WriteLine("| 3: View all Book                                      |");
            Console.WriteLine("| 4: View order                                         |");
            Console.WriteLine("| 5: Add book to oder                                   |");
            Console.WriteLine("| 6: Remove book from oder                              |");
            Console.WriteLine("| 7: View payment                                       |");
            Console.WriteLine("| 8: Logout                                             |");
            Console.WriteLine("---------------------------------------------------------");
        }
        public virtual void Register()
        {
            Console.Write("Enter a user name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Enter a password: ");
            string password = Console.ReadLine().Trim();
            Console.Write("Enter a address: ");
            string address = Console.ReadLine().Trim();
            Console.Write("Enter a phone number: ");
            string phoneNumber = Console.ReadLine().Trim();
            this.Name = name;
            this.Password = password;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
        public void ViewAllBook()
        {
            Console.WriteLine("List all book in library: ");
            if (Program.books.Count == 0) Console.WriteLine("No book in list");
            else
            foreach (var Book in Program.books)
            {
                if (Book.CheckValid() == true)
                {
                    Console.WriteLine($"{Book.DisplayBook()}");
                }
            }
        }
        public virtual void ViewProfile(int id)
        {
            Console.WriteLine("Your Infomation: ");
        }

        public void AddBook()
        {
            Console.Write("Enter ID of book to add: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter quantity of this book: ");
            int quantity = int.Parse(Console.ReadLine());
            for(int i = 0; i < Program.books.Count; i++)
            {
                if (Program.books[i].ID == id && Program.books[i].CheckValid() 
                    && quantity< Program.books[i].Quantity)
                {
                    Program.orderDetails.Add(new OrderDetail(new User(this.Name, this.Password,
                        this.Address, this.PhoneNumber), Program.books[i], quantity));
                    Program.books[i].Quantity -= quantity;
                }
            }
        }
        public void RemoveBook()
        {
            Console.Write("Enter ID of book to remove: ");
            int id = int.Parse(Console.ReadLine());
            foreach (var orderDetail in Program.orderDetails)
            {
                if (orderDetail.Book.ID == id)
                {
                    for (int i = 0; i < Program.books.Count; i++)
                    {
                        if (Program.books[i].ID == id)
                        {
                            Program.books[i].Quantity += orderDetail.Quantity;
                        }
                    }
                    Program.orderDetails.Remove(orderDetail);
                    break;
                }
            }
        }
        public void ViewOrder()
        {        
            var check=false;
            foreach (var orderDetail in Program.orderDetails)
            {
                if (orderDetail.User.Name == this.Name)
                {
                    Console.WriteLine(orderDetail.ToString());
                    check=true;
                }
            }
            if (check==false)
                Console.WriteLine("No previous orders exist");
        }
        public void ViewPayment()
        {
            foreach (var payment in Program.payments)
            {
                if (payment.User.Name == this.Name)
                {
                    Console.WriteLine(payment.ToString());
                }
            }
        }

    }
}
