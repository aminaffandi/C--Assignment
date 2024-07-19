using System;
using helloworld.models;
using helloworld.controller;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using Newtonsoft.Json;

class Program{
    static void Main (string [] args){
        System.Console.WriteLine("Choose assignment:");
        if (args.Length == 0){
            System.Console.WriteLine("No assignment was choosed");
            return;
        }
        string assignment = args[0].ToLower();
        switch (assignment){
            case "week1":
                System.Console.WriteLine("Week 1 Assignment");
                Week1Assignment();
                break;
            case "week2":
                System.Console.WriteLine("Week 2 Assignment");
                Week2Assignment();
                break;
            case "week3":
                System.Console.WriteLine("Week 3 Assignment");
                Week3Assignment();
                break;
            case "week4":
                System.Console.WriteLine("Week 4 Assignment");
                Week4Assignment();
                break;
            case "week5":
                System.Console.WriteLine("Week 5 Assignment");
                Week5Assignment();
                break;
            default:
                System.Console.WriteLine("Invalid input given");
                break;
        }

    }

    static void Week1Assignment() {
        // Week 1 Assignment
        System.Console.Write("Enter your name:");
        string name = Console.ReadLine();
        System.Console.Write("Enter your age:");
        string agenumber = Console.ReadLine();
        int age;
        if (!int.TryParse(agenumber, out age)) {
            Console.WriteLine("Invalid age input.");
            return;
        }
        System.Console.Write("Unlease your moto! :");
        string moto = Console.ReadLine();

        Week1Model user = new Week1Model {
            Name = name,
            Age = age,
            Moto = moto,
        };
        Week1Controller userController =  new Week1Controller();
        userController.UserDetails(user);
    }

    static void Week2Assignment(){

        // int input
        System.Console.Write("Enter a number:");

        // assign input to cns and star
        string n = Console.ReadLine();
        int cns_input = int.Parse(n);
        int star_input = int.Parse(n);

        // star
        Week2Model input = new Week2Model{
            CnS = cns_input,
            StarCount = star_input
        };

        Week2Controller controller = new Week2Controller();
        System.Console.WriteLine("Count and Say:");
        string result = controller.cns_output(input);
        Console.WriteLine($"The {n}th sequence in the count-and-say sequence is: {result}");
        System.Console.WriteLine("Diamond:");
        controller.star_output(input);
    }

    static void Week3Assignment(){
        System.Console.Write("Enter first number: ");
        string s0 = Console.ReadLine();
        int n0 = int.Parse(s0);
        System.Console.Write("Enter second number: ");
        string s1 = Console.ReadLine();
        int n1 = int.Parse(s1);
        System.Console.Write("Enter third number: ");
        string s2 = Console.ReadLine();
        int n2 = int.Parse(s2);
        System.Console.Write("Enter fourth number: ");
        string s3 = Console.ReadLine();
        int n3 = int.Parse(s3);
        System.Console.Write("Enter target output: ");
        string output = Console.ReadLine();
        int target = int.Parse(output);

        int [] numbers = {n0, n1, n2, n3};

        Week3Model Numbers = new Week3Model();
        Numbers.inputArray = numbers;
        Numbers.Target = target;

        string display = string.Join(", ", Numbers.inputArray);
        System.Console.WriteLine($"( {display} )");

        Week3Controller controller = new Week3Controller();
        // controller function
        string result = controller.targetOutput(Numbers.inputArray, Numbers.Target);
        System.Console.WriteLine(result);

    }

    static void Week4Assignment(){
        // dotnet add package EPPlus --version 5.6.3
        string FilePath = "./assets/students.xlsx";
        Week4Controller controller = new Week4Controller();
        var excel = controller.LoadExcel(FilePath);
        controller.getName(excel);
        System.Console.WriteLine();
        controller.getStudentScore(excel);
        System.Console.WriteLine();
        controller.getPerformStudent(excel);
        System.Console.WriteLine();
        controller.getTopThreeStudent(excel);
        System.Console.WriteLine();
    }

    static void Week5Assignment(){
        Week5Controller controller = new Week5Controller();
        string filePath = "./assets/students.json";
        controller.DisplayStudent(filePath);
        controller.AddStudent(filePath, "Hazim", "Male", 40);
        // controller.RemoveStudent(filePath, "Hazim");
        controller.EditStudentScore(filePath, "Hazim", 100);
    }
}