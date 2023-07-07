using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI2910Lab3
{
    internal class Phone
    {
        private static readonly string[] InvalidStartDigits = { "0", "1" };

        public string Number { get; }

        public Phone()
        {
            Random random = new Random();
            Number = GeneratePhoneNumber(random);
        }

        public string Format(string separator)
        {
            return Number.Insert(3, separator).Insert(7, separator);
        }

        public override string ToString()
        {
            return Number;
        }

        private string GeneratePhoneNumber(Random random)
        {
            string startDigit = GetRandomNonInvalidStartDigit(random);
            string number = startDigit;

            for (int i = 0; i < 9; i++)
            {
                number += random.Next(10).ToString();
            }

            return number;
        }

        private string GetRandomNonInvalidStartDigit(Random random)
        {
            string startDigit = InvalidStartDigits[random.Next(InvalidStartDigits.Length)];

            while (startDigit == "0" || startDigit == "1")
            {
                startDigit = random.Next(10).ToString();
            }

            return startDigit;
        }
    }
}
