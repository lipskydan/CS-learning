using System;
using System.Text;

namespace Udemy_Unit2__UserProfile
{
    class UserProfile
    {
        string firstName;
        string secondName;
        int age;
        double height;
        double weight;
        double bodyMassIndex;

        public UserProfile(string firstName, string secondName, int age, double height, double weight)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.age = age;
            this.height = height;
            this.weight = weight;

            Console.WriteLine("User was created");
        }

        public void CountBodyMassIndex()
        {
            bodyMassIndex = weight / (Math.Pow(height,2));
        }

        public void GetInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Your profile:");
            str.AppendLine($"Full Name: {this.secondName}, {this.firstName}");
            str.AppendLine($"Age: {this.age}");
            str.AppendLine($"Weight: {this.weight}");
            str.AppendLine($"Height: {this.height}");
            str.AppendLine($"Body Mass Index: {this.bodyMassIndex}");

            Console.WriteLine(str.ToString());
        }

        public string FirstName{ get; set;}
        public string SecondName{ get; set;}
        public string Age{ get; set;}
        public string Height{ get; set;}
         public string Weight{ get; set;}
    }
}