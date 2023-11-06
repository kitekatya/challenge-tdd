using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == null)
                throw new FormatException();
            
            var stringNew = postfixExpression.Split().ToList();
            var result = 0.0;
            // это не будет сдаваться....... :(
            //:(((((
            //for (int i = 0; i < stringNew.Count - 2; i ++)
            while (stringNew.Count != 1) 
            {
                if (stringNew.Count == 2)
                    throw new FormatException();
                if (IsDigit(stringNew[0]) && IsDigit(stringNew[1])) 
                {
                    if (stringNew[2] == "+") 
                    {
                        result = Double.Parse(stringNew[0]) + Double.Parse(stringNew[1]);
                    }
                    else if (stringNew[2] == "-") 
                    {
                        result = Double.Parse(stringNew[0]) - Double.Parse(stringNew[1]);
                    }
                    else if (stringNew[2] == "*") 
                    {
                        result = Double.Parse(stringNew[0]) * Double.Parse(stringNew[1]);
                    }
                    else 
                    {
                        throw new FormatException();
                    }
                    stringNew.RemoveAt(0);
                    stringNew.RemoveAt(0);
                    stringNew[0] = result.ToString();
                }
                else throw new FormatException();
            }
            
            if (postfixExpression == "") 
            {
                return "0";
            }
            if (IsDigit(stringNew[0]))
                return stringNew[0];
            else throw new FormatException();
            
        }
        
        private static bool IsDigit(string str)
        {
            var isDigit = true;
            var i = 0;
            if (str[0] == '-') i = 1;
            for (; i < str.Length; i ++)
            {
                if (!Char.IsDigit(str[i]))
                    return false;
            }

            return isDigit;
        }
    }
}
