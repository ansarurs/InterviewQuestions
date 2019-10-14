using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        /// Generate the camel case of a string with out special characters
        public static string CamelCase(string str)
            {

            // code goes here
            TextInfo tinfo = new CultureInfo("en-US", false).TextInfo;
            str = tinfo.ToLower(str);
            str= Regex.Replace(tinfo.ToTitleCase(str),@"[^a-zA-Z]+","");

              return str[0].ToString().ToLower()+ str.Substring(1);

            }

            //// if the string contains the longest substring of a palindrome
            // Example : input :InterviewweivQestions  output : view
            // the approach is 
            public static string longestPalSubstr(string str)
        {
            int totalLen = 1;
            int begin = 0;
            int length = str.Length;
            int low, high;

            for (int i = 1; i < length; i++)
            {
                low = i - 1;// expand based on the range
                high = i;
                //Even palindroms
                while (low>=0&&high<length && str[low]== str[high])
                {
                    if (high-low+1>totalLen)
                    {
                        begin = low;
                        totalLen = high - low + 1;


                    }
                    --low;
                    ++high;
                }

                // find the odd palindroms
                low = i - 1;
                high = i + 1;
                while (low>0&&high<length && str[low]== str[high])
                {
                    if (high-low+1 >totalLen)
                    {
                        begin = low;
                        totalLen = high - low + 1;

                    }
                    --low;
                    ++high;

                }

            }

            string palindStr = str.Substring(begin, (((begin + totalLen - 1) + 1) - begin));
            if (palindStr.Length <= 2)
            {
                palindStr = "none";
            }
            return palindStr;
        }
    }
}
