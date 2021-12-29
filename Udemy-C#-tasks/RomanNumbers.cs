using System;
using System.Collections.Generic;

namespace Udemy_Unit5__tasks
{
    class RomanNumbers
    {
        static Dictionary<char, int> romanNumbers = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        public static int Parse(string roman)
        {
            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i+1 < roman.Length && IsSubstractive(roman[i], roman[i+1]))
                {
                    result -= romanNumbers[roman[i]];
                }
                else
                {
                    result += romanNumbers[roman[i]];
                }
            }
            return result;
        }

        static bool IsSubstractive(char cur, char next)
        {
            return romanNumbers[cur] < romanNumbers[next];
        }
    }
}