using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetHelpers
{
    public static class StrHelpers
    {
        public static Random Rnd = new Random();
        public static string CharsList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string StrBetween(string str, string right, string left)
        {
            int posA = str.IndexOf(right);
            int posB = str.LastIndexOf(left);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + right.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return str.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static string StrLeft(string str, int charnumber)
        {
            if (string.IsNullOrEmpty(str)) return str;
            charnumber = Math.Abs(charnumber);
            return (str.Length <= charnumber ? str : str.Substring(0, charnumber));
        }

        public static string StrRight(string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string RandomString(int size)
        {
            char[] buffer = new char[size];
            for (int i = 0; i < size; i++)
            {
                buffer[i] = CharsList[Rnd.Next(CharsList.Length)];
            }
            return new string(buffer);
        }
    }
}
