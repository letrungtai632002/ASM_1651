using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class OrderDetail
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public OrderDetail(User user, Book book, int quantity)
        {
            if (Program.orderDetails.Count > 0)
            {
                int setID = Program.orderDetails[Program.orderDetails.Count - 1].Id;
                Id = setID + 1;
            }
            else Id = 1;
            User = user;
            Book = book;
            Quantity = quantity;
        }
        public string ToString()
        {
            return $"ID: {Id} User:{User.Name} Book: {Book.Name} " +
                $"Quantity: {Quantity} Subtotal: {Quantity * Book.Price} ";
        }
    }
}
