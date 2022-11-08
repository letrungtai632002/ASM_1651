using System.Reflection.Metadata;
using System.Threading.Channels;

namespace _1651ASMAPP
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();
        public static List<Professor> professors = new List<Professor>();
        public static List<Book> books = new List<Book>();
        public static List<OrderDetail> orderDetails = new List<OrderDetail>();
        public static List<Payment> payments = new List<Payment>();
        public static List<Manager> managers = new List<Manager>();

        static void Main( string[] args)
        {
            managers.Add(new Manager("manager", "1234"));
            books.Add(new Book("Nha gia kim","Paulo Coelho", 1988,10,2));
            books.Add(new Book("Dac nhan tam", "Dale Carnegie", 1936, 5, 4));
            students.Add(new Student("tai","tai","123NQ","0111","GBD11"));
            string option = "";
            do
            {
                Console.WriteLine("  ------------------Library------------------");
                Console.WriteLine("  |Enter your option from 1 to 5:           |");
                Console.WriteLine("  | 1: Register an account                  |");
                Console.WriteLine("  | 2: Login as Student                     |");
                Console.WriteLine("  | 3: Login as Professor                   |");
                Console.WriteLine("  | 4: Login as Manager                     |");
                Console.WriteLine("  | 5: Exit App                             |");
                Console.WriteLine("  -------------------------------------------");
                Console.Write("Your option: ");
                option = Console.ReadLine().Trim();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter your profession");
                        Console.WriteLine("1: Student");
                        Console.WriteLine("2: Professor");
                        Console.Write("Your option: ");
                        var profession = Console.ReadLine().Trim();
                        if (profession == "1")
                        {
                            var student = new Student();
                            student.Register();
                            students.Add(student);
                        }
                        else
                        {
                            var professor = new Professor();
                            professor.Register();
                            professors.Add(professor);
                        }
                        break;
                    case "2":
                        
                            var login = StudentLogin();
                            if (login == -1)
                            {
                                Console.WriteLine("Name or password is wrong");
                            }
                            else
                            {
                                Console.WriteLine("Login succecfully");
                                var student = students[login];
                                student.ViewMenu();
                                var choose = "";
                                do
                                {
                                    Console.Write("Enter your option: ");
                                    choose = Console.ReadLine().Trim();
                                    switch (choose)
                                    {
                                        case "1":
                                            student.ViewProfile(student.Id);
                                            break;
                                        case "2":
                                            Console.Write("Enter name of book to search: ");
                                            var name = Console.ReadLine().Trim();
                                            student.SearchBook(name);
                                            break;
                                        case "3":
                                            student.ViewAllBook();
                                            break;
                                        case "4":
                                            student.ViewOrder();
                                            break;
                                        case "5":
                                            student.AddBook();
                                            break;
                                        case "6":
                                            student.RemoveBook();
                                            break;
                                        case "7":
                                            payments.Add(new Payment(student));
                                            student.ViewPayment();
                                            break;
                                        case "8":
                                            Console.WriteLine("Logged out");
                                            break;
                                    }
                                } while (choose != "8");
                            }
                        break;
                    case "3":
                            var professorLogin = ProfessorLogin();
                            if (professorLogin == -1)
                            {
                                Console.WriteLine("Name or password is wrong");
                            }
                            else
                            {
                                Console.WriteLine("Login succecfully");
                                var professor = professors[professorLogin];
                                professor.ViewMenu();
                                var choose = "";
                                do
                                {
                                    Console.Write("Enter your option: ");
                                    choose = Console.ReadLine().Trim();
                                    switch (choose)
                                    {
                                        case "1":
                                            professor.ViewProfile(professor.Id);
                                            break;
                                        case "2":
                                            Console.Write("Enter name of book to search: ");
                                            var name = Console.ReadLine().Trim();
                                            professor.SearchBook(name);
                                            break;
                                        case "3":
                                            professor.ViewAllBook();
                                            break;
                                        case "4":
                                            professor.ViewOrder();
                                            break;
                                        case "5":
                                            professor.AddBook();
                                            break;
                                        case "6":
                                            professor.RemoveBook();
                                            break;
                                        case "7":
                                            payments.Add(new Payment(professor));
                                            professor.ViewPayment();
                                            break;
                                        case "8":
                                            Console.WriteLine("Logged out");
                                            break;
                                    }
                                } while (choose != "8");
                            }
                        break;
                    case "4":
                        var managerLogin = ManagerLogin();
                        if (managerLogin == -1)
                        {
                            Console.WriteLine("Name or password is wrong");
                        }
                        else
                        {
                            Console.WriteLine("Login succecfully");
                            var manager = managers[managerLogin];
                            manager.ViewMenu();
                            var choose = "";
                            do
                            {
                                Console.Write("Enter your option: ");
                                choose = Console.ReadLine().Trim();
                                switch (choose)
                                {
                                    case "1":
                                        Console.Write("Enter name of book to search: ");
                                        var name = Console.ReadLine().Trim();
                                        manager.SearchBook(name);
                                        break;
                                    case "2":
                                        manager.ViewAllBook();
                                        break;
                                    case "3":
                                        manager.ViewAllOrder();
                                        break;
                                    case "4":
                                        manager.ViewAllPayment();
                                        break;
                                    case "5":
                                        Console.WriteLine("All student:");
                                        manager.ViewAllStudent();
                                        break;
                                    case "6":
                                        Console.WriteLine("All professor");
                                        manager.ViewAllProfessor();
                                        break;
                                    case "7":
                                        manager.AddBook();
                                        break;
                                    case "8":
                                        manager.DeleteBook();
                                        break;
                                    case "9":
                                        manager.UpdateBook();
                                        break;
                                    case "10":
                                        Console.WriteLine("Logged out");
                                        break;
                                }
                            } while (choose != "10");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Thank you");
                        break;
                }
            }
            while (option != "5");
        }
        public static int StudentLogin()
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine().Trim();
            Console.Write("Enter password: ");
            var pass = Console.ReadLine().Trim();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name && students[i].Password == pass)
                        return(i);
            }
            return(-1);
        }
        public static int ProfessorLogin()
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine().Trim();
            Console.Write("Enter password: ");
            var pass = Console.ReadLine().Trim();
            for (int i = 0; i < professors.Count; i++)
            {
                if (professors[i].Name == name && professors[i].Password == pass)
                    return (i);
            }
            return (-1);
        }
        public static int ManagerLogin()
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine().Trim();
            Console.Write("Enter password: ");
            var pass = Console.ReadLine().Trim();
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Name == name && managers[i].Password == pass)
                    return (i);
            }
            return (-1);
        }


    }
}