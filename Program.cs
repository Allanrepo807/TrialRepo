using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, Student> Students = new Dictionary<int, Student>();

    static void Main()
    {
        bool flag = false;

        while (!flag)
        {
            Console.Clear();
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1: Add Student");
            Console.WriteLine("2: Remove Student");
            Console.WriteLine("3: View Student");
            Console.WriteLine("4: View All Students");
            Console.WriteLine("5: Remove All Students");
            Console.WriteLine("6 Enter Student Marks");
            Console.WriteLine("7: Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    RemoveStudent();
                    break;
                case "3":
                    ViewStudent();
                    break;
                case "4":
                    ViewAllStudents();
                    break;
                case "5":
                    RemoveAllStudents();
                    break;
                case "6":
                    EnterStudentMarks();
                    break;
                case "7":
                    flag = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Clear();
        Console.Write("Enter the name of the student: ");
        string name = Console.ReadLine();

        Console.Write("Enter the student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.WriteLine("Invalid sudent id.Press any key to continue");
            Console.ReadKey();
            return;
        }

        if (Students.ContainsKey(studentId))
        {
            Console.WriteLine("Student ID already exists. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter the date of birth (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            Console.WriteLine("Invalid date format. Please try again.");
            Console.ReadKey();
            return;
        }

        Students.Add(studentId, new Student(name, studentId, dob));

        Console.WriteLine("Student added successfully. Press any key to continue.");
        Console.ReadKey();
    }

    static void RemoveStudent()
    {
        Console.Clear();
        Console.Write("Enter the student ID to remove: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId) || !Students.ContainsKey(studentId))
        {
            Console.WriteLine("Student not found. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Students.Remove(studentId);
        Console.WriteLine("Student removed successfully. Press any key to continue.");
        Console.ReadKey();
    }

    static void ViewStudent()
    {
        Console.Clear();
        Console.Write("Enter the student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId) || !Students.ContainsKey(studentId))
        {
            Console.WriteLine("Student not found. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Students[studentId].Display();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    static void RemoveAllStudents(){
        Console.Clear();
        Students.Clear();
        Console.WriteLine("Removed all the Students from the memory. Press any key to continue");
        Console.ReadKey();
    }


    static void ViewAllStudents()
    {
        Console.Clear();
        Console.WriteLine("==== Viewing all Student ====");

        if (Students.Count == 0){
            Console.WriteLine("No student present in the memory");
 
        }
        else{
            foreach(var st in Students.Values){
                st.Display();
                Console.WriteLine("--------------------------");

            }
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    static void EnterStudentMarks()
    {
        Console.Clear();
        Console.WriteLine("Enter the Student ID:");

        if (!int.TryParse(Console.ReadLine(), out int studentId) || !Students.ContainsKey(studentId))
        {
            Console.WriteLine("Invalid Student ID. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        var marks = new Dictionary<string, int>();
        var subjects = new List<string> { "Discrete Mathematics", "English", "Database Management", "Python", "SQL" };

        foreach (var sub in subjects)
        {
            Console.Write($"{sub}: ");
            int input;

            while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 100)
            {
                Console.WriteLine("Invalid Marks. Enter a value between 0 and 100.");
                Console.Write($"{sub}: "); 
            }

            marks[sub] = input;  
        }


        Students[studentId].Setreport(marks); 
        Console.WriteLine("Marks added successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}



class Student
{
    private string Name { get; set; }
    private int StudentId { get; set; }
    private DateTime DOB { get; set; }
    private Dictionary<string,int> reports = new Dictionary<string,int>();



    public Student(string name, int studentId, DateTime dob)
    {
        Name = name;
        StudentId = studentId;
        DOB = dob;
    }

    public void Setreport(Dictionary <string,int> marks)
    {
        reports = marks;
    }


    public void Display()
    {
        Console.WriteLine("===== Student Information =====");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Date of Birth: {DOB:yyyy-MM-dd}");
        Console.WriteLine("---- The student Report ----");
        foreach(var report in reports)
        {
            Console.WriteLine($"{report.Key}:{report.Value}");
        }
    }
}
