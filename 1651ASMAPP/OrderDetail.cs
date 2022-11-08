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
        public string UserName { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public OrderDetail(string name, Book book, int quantity)
        {
            if (Program.orderDetails.Count > 0)
            {
                int setID = Program.orderDetails[Program.orderDetails.Count - 1].Id;
                Id = setID + 1;
            }
            else Id = 1;
            UserName = name;
            Book = book;
            Quantity = quantity;
        }
        public string ToString()
        {
            return $"ID: {Id} User:{UserName} Book: {Book.Name} " +
                $"Quantity: {Quantity} Subtotal: {Quantity * Book.Price} ";
        }
    }
}
