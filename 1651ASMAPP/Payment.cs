using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1651ASMAPP
{
    internal class Payment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Payment(User user)
        {
            if (Program.students.Count > 0)
            {
                int setID = Program.students[Program.students.Count - 1].Id;
                Id = setID + 1;
            }
            else Id = 1;
            User = user;
        }
        public string ToString()
        {
            decimal total = 0;
            foreach (var order in Program.orderDetails)
            {
                if (order.User.Name == this.User.Name)
                {
                    total += order.Quantity * order.Book.Price;
                }
            }
            return $"ID: {Id} User:{User.Name} Amount: {total} ";
        }

    }
}
