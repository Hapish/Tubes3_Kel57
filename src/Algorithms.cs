using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace tubes3stima
{
    public class KMPAlgorithm
    {
        // Function to create the LPS array
        private static int[] ComputeLPSArray(string pattern)
        {
            int length = 0;
            int i = 1;
            int[] lps = new int[pattern.Length];
            lps[0] = 0; 

            // Loop to get the LPS for every index
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        // KMP Function
        public static bool KMPSearch(string text, string pattern)
        {
            int M = pattern.Length;
            int N = text.Length;

            // Get LPS
            int[] lps = ComputeLPSArray(pattern);
            
            int i = 0; // Index for text
            int j = 0; // Index for pattern

            bool check = false;

            // The handler for the KMP algorithm
            while (i < N)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }

                if (j == M)
                {
                    j = lps[j - 1];
                    check = true;
                }

                else if (i < N && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return check;
        }
    }

    public class BoyerMoore
    {
        private const int MAX_CHAR = 256;

        // Function to pre-process the bad character table
        private static void BadCharHandler(string pattern, int[] badChar)
        {
            int m = pattern.Length;

            for (int i = 0; i < MAX_CHAR; i++)
                badChar[i] = -1;

            for (int i = 0; i < m; i++)
                badChar[(int)pattern[i]] = i;
        }

        // Function to search for a pattern in text using Boyer-Moore algorithm
        public static bool BMSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            int[] badChar = new int[MAX_CHAR];

            BadCharHandler(pattern, badChar);

            // Shift counter
            int shift = 0;

            // Boolean value to check if the pattern is found or not
            bool check = false;

            while (shift <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pattern[j] == text[shift + j])
                    j--;

                // Shift handler within the BM algorithm 
                if (j < 0)
                {
                    check = true;
                    shift += (shift + m < n) ? m - badChar[text[shift + m]] : 1;
                }
                else
                {
                    shift += Math.Max(1, j - badChar[text[shift + j]]);
                }
            }

            return check;
        }
    }

    public class RegexNameConverter
    {
        // Placeholder. Will replace with actual name attributes in 2 different classes
        private static (string, string) GetName()
        {
            // namaSJ being the name attribute on the Sidik Jari class
            // namaBIO being the name attribute on the Biodata class
            string namaSJ = Console.ReadLine();
            string namaBIO = Console.ReadLine();
            return (namaSJ, namaBIO);
        }

        public static string ConvertWeirdName(string namaSJ, string namaBIO)
        {
            // Dictionary for all the possible letter replacements
            var replacements = new Dictionary<char, char>
            {
                { '4', 'A' }, { 'A', 'A' }, { 'a', 'A' },
                { '8', 'B' }, { 'B', 'B' }, { 'b', 'B' },
                { 'C', 'C' }, { 'c', 'C' },
                { 'D', 'D' }, { 'd', 'D' },
                { '3', 'E' }, { 'E', 'E' }, { 'e', 'E' },
                { 'F', 'F' }, { 'f', 'F' },
                { '6', 'G' }, { 'G', 'G' }, { 'g', 'G' },
                { 'H', 'H' }, { 'h', 'H' },
                { '1', 'I' }, { 'I', 'I' }, { 'i', 'I' },
                { 'J', 'J' }, { 'j', 'J' },
                { 'K', 'K' }, { 'k', 'K' },
                { 'L', 'L' }, { 'l', 'L' },
                { 'M', 'M' }, { 'm', 'M' },
                { 'N', 'N' }, { 'n', 'N' },
                { '0', 'O' }, { 'O', 'O' }, { 'o', 'O' },
                { 'P', 'P' }, { 'p', 'P' },
                { 'Q', 'Q' }, { 'q', 'Q' },
                { 'R', 'R' }, { 'r', 'R' },
                { '5', 'S' }, { 'S', 'S' }, { 's', 'S' },
                { '7', 'T' }, { 'T', 'T' }, { 't', 'T' },
                { 'U', 'U' }, { 'u', 'U' },
                { 'V', 'V' }, { 'v', 'V' },
                { 'W', 'W' }, { 'w', 'W' },
                { 'X', 'X' }, { 'x', 'X' },
                { 'Y', 'Y' }, { 'y', 'Y' },
                { 'Z', 'Z' }, { 'z', 'Z' }
            };

            // Regular expression to match the dictionary above
            string pattern = "[4Aa8BbCcDd3EeFf6GgHh1IiJjKkLlMmNn0OoPpQqRr5Ss7TtUuVvWwXxYyZz]";

            int sjIndex = 0;
            List<char> convertedName = new List<char>();

            string ReplaceCharacters(Match match)
            {
                if (sjIndex >= namaSJ.Length)
                    return match.Value;

                char sjChar = namaSJ[sjIndex];
                char bioChar = match.Value[0];

                sjIndex++;

                if (replacements.TryGetValue(bioChar, out char replacement) &&
                    char.ToUpper(replacement) == char.ToUpper(sjChar))
                {
                    return (char.IsUpper(sjChar) ? char.ToUpper(sjChar) : char.ToLower(sjChar)).ToString();
                }

                return sjChar.ToString();
            }

            // Use Regex.Replace to perform the conversion
            string convertedNameString = Regex.Replace(namaBIO, pattern, new MatchEvaluator(ReplaceCharacters));

            // Add certain characters to fix the shortening of namaBIO
            if (sjIndex < namaSJ.Length)
            {
                convertedNameString += namaSJ.Substring(sjIndex);
            }

            return convertedNameString;
        }
        public static string ConvertNameIfSimilar(string sidikJariName, string biodataName)
        {
            int levenshteinDistance = LevenshteinDistanceCalculator.LevenshteinDistance(sidikJariName, biodataName);
            int nameLength = Math.Max(sidikJariName.Length, biodataName.Length);
            int similarityPercentage = 100 - (levenshteinDistance * 100 / nameLength);

            if (similarityPercentage >= 80)
            {
                return RegexNameConverter.ConvertWeirdName(sidikJariName, biodataName);
            }

            return biodataName;
        }
    }

    public class LevenshteinDistanceCalculator
    {
        // Function to get the actual Levenshtein Distance
        public static int LevenshteinDistance(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;

            int[,] distance = new int[len1 + 1, len2 + 1];

            // Initialize the distance matrix
            for (int i = 0; i <= len1; i++)
            {
                distance[i, 0] = i;
            }
            for (int j = 0; j <= len2; j++)
            {
                distance[0, j] = j;
            }

            // Compute the distance
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(
                        Math.Min(distance[i - 1, j] + 1,    
                                 distance[i, j - 1] + 1),   
                                 distance[i - 1, j - 1] + cost); 
                }
            }
            int levenDistance = distance[len1, len2];
            return levenDistance;
        }

        // Function to search the percentage of similarity between both strings
        public static int DifferencePercentage(int levenDistance, string s1, string s2)
        {
            int percent = 100 - (levenDistance * 100 / Math.Max(s1.Length, s2.Length));

            return percent;
        }
    }
}