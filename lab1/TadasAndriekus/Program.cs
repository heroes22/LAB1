/*
  
//RANDOM UZDUOTIES PARINKIMAS


using System;
using System.Linq;


  
 public class StudentProfile // Studento profilis
{
    public string Vardas { get; set; } = "Tadas";
    public string Pavarde { get; set; } = "Andriekus";
    public string Grupe { get; set; } = "PS-5";
    public DateOnly PaskaitosData { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string ToReadmeBlock(int taskNo) // Studento profilio spausdinimas
    {
        return $"""
# Užduotis {taskNo}
Studentas: {Vardas} {Pavarde}
Grupė: {Grupe}
Data: {PaskaitosData}

""";
    }
}

 public class Program
{
    public static void Main(string[] args)
    {
        var rnd = new Random(); // Random uzduoties generavimas
        var student = new StudentProfile();

        int max = args.Contains("--challenge") ? 5 : 4;
        int task = rnd.Next(1, max + 1);

        Console.WriteLine(student.ToReadmeBlock(task));

        if (task == 5)
        {
            int fallback = rnd.Next(1, 5); // fallback uzduoties generavimas
            Console.WriteLine(student.ToReadmeBlock(fallback));
        }
    }
}

*/


//Atsitiktinai parinkta 3 Uzduotis:  Konsolinis meniu (Add/Show/Exit)


using System;
using System.Collections.Generic;

public class Student
{
    public string Vardas;
    public string Pavarde;

    public Student(string vardas, string pavarde)
    {
        Vardas = vardas;
        Pavarde = pavarde;
    }
}

public class Group // Studentu grupe
{   
    private List<Student> students = new List<Student>();

    public void Add(Student s) // Studentu pridejimas
    {
        students.Add(s);
    }

    public void PrintAll() // Studentu spausdinimas
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Grupė tuščia.");
            return;
        }

        foreach (var s in students)
            Console.WriteLine(s.Vardas + " " + s.Pavarde);
    }
}

public class Program
{
    public static void Main()
    {
        Group group = new Group(); // Metodas meniu pasirinkimams
        string choice = "";

        while (choice != "0")
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Show");
            Console.WriteLine("0 - Exit");
            Console.Write("Pasirinkimas: ");
            choice = Console.ReadLine(); // Atspausdinamas pasirinkimas

            if (choice == "1")
            {
                Console.WriteLine("-----------------------");
                Console.Write("Vardas: ");
                string vardas = Console.ReadLine(); // Atspausdinamas vardas

                Console.Write("Pavardė: ");
                string pavarde = Console.ReadLine(); // Atspausdinama pavarde
                Console.WriteLine("-----------------------");

                group.Add(new Student(vardas, pavarde)); // naujo studento pridejimas prie grupes
            }
            else if (choice == "2")
            {
                Console.WriteLine("-----------------------");
                group.PrintAll();
                Console.WriteLine("-----------------------");// Visu studentu spausdinimas
            }
        }
    }
}
