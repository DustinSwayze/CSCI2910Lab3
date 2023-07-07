using System;
using System.Collections.Generic;
using System.Text;

namespace CSCI2910Lab3
{
    class Program
    {
        static List<Person> personList = new List<Person>();

        static void Main(string[] args)
        {
            //menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Create Person");
                Console.WriteLine("2. View All Persons");
                Console.WriteLine("3. View Person Details");
                Console.WriteLine("4. Remove Person");
                Console.WriteLine("5. Get Random Last Name");
                Console.WriteLine("6. Get Random SSN");
                Console.WriteLine("7. Get Random Phone Number");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreatePerson();
                        break;
                    case 2:
                        ViewAllPersons();
                        break;
                    case 3:
                        ViewPersonDetails();
                        break;
                    case 4:
                        RemovePerson();
                        break;
                    case 5:
                        GetRandomLastName();
                        break;
                    case 6:
                        GetRandomSSN();
                        break;
                    case 7:
                        GetRandomPhoneNumber();
                        break;
                    case 8:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CreatePerson()
        {
            Console.WriteLine("Enter the number of persons you want to create: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Person person = new Person();
                personList.Add(person);
                Console.WriteLine("Person created successfully.");
            }
        }

        static void ViewAllPersons()
        {
            if (personList.Count == 0)
            {
                Person person = new Person();
                personList.Add(person);
            }

            foreach (Person person in personList)
            {
                Console.WriteLine($"Person: {person.FirstName} {person.LastName}");
            }
        }

        static void ViewPersonDetails()
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("No persons found.");
                return;
            }

            Console.WriteLine("Select a person:");

            for (int i = 0; i < personList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personList[i].FirstName} {personList[i].LastName}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice > 0 && choice <= personList.Count)
            {
                Person selectedPerson = personList[choice - 1];
                Console.WriteLine("Person Details:");
                Console.WriteLine(selectedPerson.ToString());
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void RemovePerson()
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("No persons found.");
                return;
            }

            Console.WriteLine("Select a person to remove:");

            for (int i = 0; i < personList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personList[i].FirstName} {personList[i].LastName}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice > 0 && choice <= personList.Count)
            {
                personList.RemoveAt(choice - 1);
                Console.WriteLine("Person removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void GetRandomLastName()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(LastName));
            LastName randomLastName = (LastName)values.GetValue(random.Next(values.Length));
            Console.WriteLine($"Random Last Name: {randomLastName}");
        }

        static void GetRandomSSN()
        {
            SSN ssn = new SSN();
            Console.WriteLine($"Random SSN: {ssn.ToString()}");
        }

        static void GetRandomPhoneNumber()
        {
            Console.WriteLine("Enter the separator for the phone number: ");
            string separator = Console.ReadLine();

            Phone phone = new Phone();
            Console.WriteLine($"Random Phone Number: {phone.Format(separator)}");
        }
    }
}