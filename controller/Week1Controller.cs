using helloworld.models;

namespace helloworld.controller{
    public class Week1Controller{
        public void UserDetails(Week1Model user){
            System.Console.WriteLine($"My name is {user.Name}. \nI am {user.Age} years old. \nMy moto for today is {user.Moto}!");
        }
    }
}