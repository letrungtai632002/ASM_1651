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
        public string UserName { get; set; }
        public Payment(string name)
        {
            if (Program.students.Count > 0)
            {
                int setID = Program.students[Program.students.Count - 1].Id;
                Id = setID + 1;
            }
            else Id = 1;
            UserName = name;
        }
        public string ToString()
        {
            decimal total = 0;
            foreach (var order in Program.orderDetails)
            {
                if (order.UserName == this.UserName)
                {
                    total += order.Quantity * order.Book.Price;
                }
            }
            return $"ID: {Id} User:{UserName} Amount: {total} ";
        }

    }
}
