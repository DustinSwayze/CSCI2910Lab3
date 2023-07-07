using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI2910Lab3
{
    class Dependent : Person
    {
        public Dependent() : base()
        {
            Random random = new Random();
            BirthDate = DateTime.Now.AddDays(random.Next(365 * 10));
        }

        public override string ToString()
        {
            return $"- Dependent: {FirstName} {LastName} (Birth Date: {BirthDate.ToShortDateString()})";
        }
    }
}
