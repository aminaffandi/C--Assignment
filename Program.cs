using System;
using helloworld.models;
using helloworld.controller;

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
}