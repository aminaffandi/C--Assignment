using System;
using helloworld.models;
using helloworld.controller;

class Program{
    static void Main (string [] args){
        // process week1_model
        System.Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        System.Console.WriteLine("Enter your age:");
        string agenumber = Console.ReadLine();
        int age;
        if (!int.TryParse(agenumber, out age)) {
            Console.WriteLine("Invalid age input.");
            return;
        }

        System.Console.WriteLine("Unlease your moto! :");
        string moto = Console.ReadLine();

        Week1Model user = new Week1Model {
            Name = name,
            Age = age,
            Moto = moto,
        };

        Week1Controller userController =  new Week1Controller();
        userController.UserDetails(user);

    }
}