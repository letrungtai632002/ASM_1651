using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class Book
    {
        private int id, yearOfPublish;
        private string name, author;
        private int quantity;
        private decimal price;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set 
            {
                var str = value.Split();
                if (Char.IsLower(str[0][0]))
                    throw new ArgumentException("Name of Book not valid!");
                if (value.Length < 3)
                    throw new ArgumentException("Name of Book not valid!");
                name = value;
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                var str = value.Split();
                if (Char.IsLower(str[0][0]))
                    throw new ArgumentException("Author of Book not valid!");
                if (Char.IsDigit(str[0][0]))
                    throw new ArgumentException("Author of Book not valid!");
                author = value;
            }
        }
        public int YearOfPublish
        {
            get { return yearOfPublish; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Year Publish not negative!");
                yearOfPublish = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price not negative!");
                price = value;
            }
        }
        public Book(string name, string author, 
            int yearOfPublish, int quantity, decimal price)
        {
            if (Program.books.Count > 0)
            {
                int setID = Program.books[Program.books.Count-1].ID;
                ID = setID+1;
            }
            else { ID = 1; }
            Name = name;
            Author = author;
            YearOfPublish = yearOfPublish;
            Quantity = quantity;
            Price = price;
        }
        public string DisplayBook()
        {
            return $"ID: {id} Name: {name} Author: {author}" +
                $" Year punlish: {yearOfPublish} Quantity:{quantity} Price: {price}";
        }
        public bool CheckValid()
        {
            if (Quantity == 0)  return false;
            return true;
        }
    }
}
