using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.Multiply("8960510175197730055205234138804802975183902897893323146751551933121961253633424776282", "5911442006235049505159398282102625962462"));
            Console.Read();
        }

        public string Multiply(string num1, string num2)
        { 
            var nums = new List<string>();

            var maxLength = num1.Length + num2.Length;

            for (var i = num1.Length - 1; i >= 0; i--)
            {
                for (var j = num2.Length - 1; j >= 0; j--)
                {
                    var places = num1.Length + num2.Length - 2 - i - j;

                    var p1 = int.Parse(num1[i].ToString());
                    var p2 = int.Parse(num2[j].ToString());

                    var mul = (p1 * p2).ToString();
                    var length = mul.Length + places;

                    var num = mul.PadRight(length, '0').PadLeft(maxLength, '0');
                    nums.Add(num);
                }
            }

            var carry = 0;
            var ls = new List<int>();
            for (var i = maxLength - 1; i >= 0; i--)
            {
                var sum = Convert.ToInt32(nums.Sum(x => Char.GetNumericValue(x[i]))) + carry;
                carry = sum / 10;
                var digit = sum % 10;
                ls.Add(digit);
            }

            ls.Reverse();
            var stb = new StringBuilder();

            foreach (var digit in ls)
                stb.Append(digit);

            var result = stb.ToString();
            result = result.TrimStart('0');

            if (result == "")
                return "0";
            else
                return result;
        }
    }
}
