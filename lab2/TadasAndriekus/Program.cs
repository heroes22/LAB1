using System;
using System.Collections.Generic;

public class Student
{
    private string Vardas;
    private string Pavarde;

    public Student(string vardas, string pavarde)
    {
        Vardas = vardas;
        Pavarde = pavarde;
    }

    public string GetFullName()
    {
        return Vardas + " " + Pavarde;
    }
}

public class Group
{
    private List<Student> students = new List<Student>();

    public void Add(Student s)
    {
        students.Add(s);
    }

    public bool IsEmpty()
    {
        return students.Count == 0;
    }

    public List<Student> GetStudents()
    {
        return students;
    }
}

public class Menu
{
    private Group group;

    public Menu(Group group)
    {
        this.group = group;
    }

    public void Run()
    {
        string choice = "";

        while (choice != "0")
        {
            PrintMenu();
            choice = Console.ReadLine();
            HandleChoice(choice);
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("1 - Add");
        Console.WriteLine("2 - Show");
        Console.WriteLine("0 - Exit");
        Console.Write("Pasirinkimas: ");
    }

    private void HandleChoice(string choice)
    {
        if (choice == "1")
        {
            AddStudent();
        }
        else if (choice == "2")
        {
            ShowStudents();
        }
    }

    private void AddStudent()
    {
        Console.WriteLine("-----------------------");
        Console.Write("Vardas: ");
        string vardas = Console.ReadLine();

        Console.Write("Pavarde: ");
        string pavarde = Console.ReadLine();
        Console.WriteLine("-----------------------");

        group.Add(new Student(vardas, pavarde));
    }

    private void ShowStudents()
    {
        Console.WriteLine("-----------------------");

        if (group.IsEmpty())
        {
            Console.WriteLine("Grupe tuscia.");
        }
        else
        {
            foreach (var s in group.GetStudents())
            {
                Console.WriteLine(s.GetFullName());
            }
        }

        Console.WriteLine("-----------------------");
    }
}

public class Program
{
    public static void Main()
    {
        Group group = new Group();
        Menu menu = new Menu(group);

        menu.Run();
    }
}