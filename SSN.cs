using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI2910Lab3
{
    internal class SSN
    {
        public string Number { get; init; }

        public SSN()
        {
            Random random = new Random();
            Number = GenerateInvalidSSN(random);
        }

        public override string ToString()
        {
            return Number;
        }

        private string GenerateInvalidSSN(Random random)
        {
            int area;
            int group;
            int serial;

            do
            {
                area = random.Next(1, 1000);
                group = random.Next(0, 100);
                serial = random.Next(0, 10000);
            } while (IsSSNValid(area, group, serial));

            return $"{area:D3}-{group:D2}-{serial:D4}";
        }

        //checking to make sure the ssn is invalid ref: https://primepay.com/blog/how-to-determine-a-valid-social-security-number/ rules
        //
        private bool IsSSNValid(int area, int group, int serial)
        {
            // Check if the generated SSN is valid based on the rules
            return !(area == 0 || area == 666 || (area >= 900 && area <= 999) || group == 0 || serial == 0);
        }

    }
}
