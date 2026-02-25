using System;
using System.Collections.Generic;

public class Student // issaugo studento varda ir pavarde (laikinai)
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
        return Vardas + " " + Pavarde; // atspausdina studento varda ir pavarde
    }
}

public class Group // studento pridejimas
{
    private List<Student> students = new List<Student>();

    public void Add(Student s)
    {
        students.Add(s); // prideda studenta
    }

    public bool IsEmpty() // patikrina ar grupe tuscia ir studentu joje nera
    {
        return students.Count == 0;
    }

    public List<Student> GetStudents()
    {
        return students; // atspausdina visus studentus (jei netuscia grupe)
    }
}

public class Menu 
{
    private Group group; // studentu grupe

    public Menu(Group group)
    {
        this.group = group;
    }

    public void Run() // kol nera ivedamas 0, tol programa veikia
    {
        string choice = "";

        while (choice != "0")
        {
            PrintMenu();
            choice = Console.ReadLine();
            HandleChoice(choice);
        }
    }

    private void PrintMenu() // meniu pasirinkimai
    {
        Console.WriteLine("1 - Add");
        Console.WriteLine("2 - Show");
        Console.WriteLine("0 - Exit");
        Console.Write("Pasirinkimas: ");
    }

    private void HandleChoice(string choice) // pasirinkimu metodas
    {
        if (choice == "1")
        {
            AddStudent(); // studento pridejimas
        }
        else if (choice == "2")
        {
            ShowStudents(); // studento(-u) rodymas
        }
    }

    private void AddStudent() // studento pridejimo metodas
    {
        Console.WriteLine("-----------------------");
        Console.Write("Vardas: ");
        string vardas = Console.ReadLine(); // spausdinamas vardas

        Console.Write("Pavarde: ");
        string pavarde = Console.ReadLine(); // spausdinama pavarde
        Console.WriteLine("-----------------------");

        group.Add(new Student(vardas, pavarde));
    }

    private void ShowStudents() // studento rodymo metodas
    {
        Console.WriteLine("-----------------------");

        if (group.IsEmpty())
        {
            Console.WriteLine("Grupe tuscia."); // spausdinama jei grupe tuscia
        }
        else
        {
            foreach (var s in group.GetStudents()) 
            {
                Console.WriteLine(s.GetFullName()); // paima visus ivestus studentus ir atspausdina
            }
        }

        Console.WriteLine("-----------------------");
    }
}

public class Program
{
    public static void Main() // main metodas 
    {
        Group group = new Group(); // studentu grupe
        Menu menu = new Menu(group); meniu, kuriame yra  studentu grupe

        menu.Run();
    }
}
