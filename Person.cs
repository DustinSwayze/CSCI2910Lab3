using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI2910Lab3
{
    internal class Person
    {
        private static string[] _arrayOfFirstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Daniel", "Emma", "Christopher", "Olivia" };
        private List<Dependent> _dependents = new List<Dependent>();


        //init -- looks like this is fairly new and not something we learned about in the intro classes:  init allows the property to be set once at object creation, and then becomes immutable. saves on repeated code.
        public string FirstName { get; init; }
        public LastName LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public string SSN { get; init; }
        public string Phone { get; init; }

        public Person()
        {
            Random random = new Random();

            FirstName = _arrayOfFirstNames[random.Next(_arrayOfFirstNames.Length)];
            LastName = GetRandomEnumValue<LastName>();
            BirthDate = DateTime.Now.AddYears(-random.Next(18, 80)).AddDays(-random.Next(365));
            SSN = new SSN().ToString();
            Phone = new Phone().ToString();
        }

        public int Age()
        {
            //cast to an int, the result of the rounded down result of the time between the birthday and now
            return (int)Math.Floor((DateTime.Now - BirthDate).TotalDays / 365.25);
        }

        public void AddDependent(Dependent dependent)
        {
            _dependents.Add(dependent);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"First Name: {FirstName}");
            builder.AppendLine($"Last Name: {LastName}");
            builder.AppendLine($"Birth Date: {BirthDate.ToShortDateString()}");
            builder.AppendLine($"Age: {Age()}");
            builder.AppendLine($"SSN: {SSN}");
            builder.AppendLine($"Phone: {Phone}");
            builder.AppendLine("Dependents:");

            if (_dependents.Count > 0)
            {
                foreach (Dependent dependent in _dependents)
                {
                    builder.AppendLine(dependent.ToString());
                }
            }
            else
            {
                builder.AppendLine("No dependents.");
            }

            return builder.ToString();
        }

        private static T GetRandomEnumValue<T>()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }
    }
}
