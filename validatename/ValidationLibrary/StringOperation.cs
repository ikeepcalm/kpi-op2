
using System;
using System.Text;

namespace ValidationLibrary
{
    public static class StringOperation
    {
        public static string GetValidName (string nameToValidate){
            
            nameToValidate = RemoveNonLatinLetters(nameToValidate);
            
            if (nameToValidate.Length > 50)
            {
                nameToValidate = nameToValidate.Substring(0, 50);
            }
            
            if (string.IsNullOrWhiteSpace(nameToValidate))
            {
                throw new ArgumentException("Name is null or empty.");
            }
            
            nameToValidate = nameToValidate.TrimStart();
            
            int firstSpaceIndex = nameToValidate.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return FormatSingleWord(nameToValidate);
            }
            
            int nextNonSpaceIndex = firstSpaceIndex + 1;
            while (nextNonSpaceIndex < nameToValidate.Length && nameToValidate[nextNonSpaceIndex] == ' ')
            {
                nextNonSpaceIndex++;
            }
            nameToValidate = string.Concat(nameToValidate.AsSpan(0, firstSpaceIndex), " ", nameToValidate.AsSpan(nextNonSpaceIndex));
            
            nameToValidate = nameToValidate.TrimEnd();
            
            nameToValidate = nameToValidate.ToLower();
            
            string[] words = nameToValidate.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder resultBuilder = new StringBuilder();
            foreach (string word in words)
            {
                resultBuilder.Append(char.ToUpper(word[0]) + word.Substring(1)).Append(' ');
            }
            return resultBuilder.ToString().TrimEnd();
        }
        
        private static string RemoveNonLatinLetters(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Name is null or empty.");
            }
            
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        
        private static string FormatSingleWord(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}