using StudentCRUD.Appllication.Service;
using StudentCRUD.Domain.Models;

namespace StudentCRUD
{
    public class Program
    {
        private static StudentService _studentService = new();
        static void Main(string[] args)
        {
            bool isChoice = false;
            while (!isChoice)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t~~~~~Assalomu alaykum!~~~~~~");
                Console.ResetColor();
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Update Student");
                Console.WriteLine("3.Search by Id Student");
                Console.WriteLine("4.Search by Name Student");
                Console.WriteLine("5.Read Students");
                Console.WriteLine("6.Remove by id Student");
                Console.WriteLine("*.EXIT");
                Console.Beep();
                Console.Write("Choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": UpdateStudent(); break;
                    case "3": SearchByID(); break;
                    case "4": SearchByFirstName(); break;
                    case "5": GetAllStudent(); break;
                    case "6": DeleteStudent(); break;
                    case "*": return;
                    default: Console.WriteLine("Wrong choice"); break;
                }

            }
        }

        static void AddStudent()
        {
            Console.Write("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("FisrtName:");
            string firstName = Console.ReadLine();

            Console.Write("LastName:");
            string lastName = Console.ReadLine();

            Console.Write("Age:");
            int age = int.Parse(Console.ReadLine());

            _studentService.Added(new Student { Id = id, FirstName = firstName, LastName = lastName, Age = age });
            Console.WriteLine("Student Added!");
        }

        static void UpdateStudent()
        {
            Console.Write("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("FisrtName:");
            string firstName = Console.ReadLine();

            Console.Write("LastName:");
            string lastName = Console.ReadLine();

            Console.Write("Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine(_studentService.UpdateStudent(new Student
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            })
                ? "Upadeted!!!"
                : "Not searched");
        }

        static void SearchByID()
        {
            Console.Write("ID:");
            int id = int.Parse(Console.ReadLine());

            var s = _studentService.GetByIdStudent(id);
            Console.WriteLine(s == null ? "No" : $"{s.Id} | {s.FirstName} | {s.LastName} | {s.Age} | ");
        }

        static void SearchByFirstName()
        {
            Console.WriteLine("FirstName:");
            string FisrtName = Console.ReadLine();

            foreach (var s in _studentService.GetByName(FisrtName))
                Console.WriteLine($"{s.Id} | {s.FirstName} | {s.Age}");
        }

        static void GetAllStudent()
        {
            foreach (var s in _studentService.GetAllStudents())
                Console.WriteLine($"{s.Id} | {s.FirstName} | {s.Age}");
        }

        static void DeleteStudent()
        {
            Console.WriteLine("ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(
                _studentService.DeleteStudent(id)
                ? "Deleted!"
                : "Not Searched"
                );
        }
    }
}
