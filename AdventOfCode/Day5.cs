namespace AdventOfCode
{
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;

    public class Day5
    {
        public bool IsNice(string value)
        {
            // value contains at least 3 vowels
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            if (!ContainsVowels(value, vowels))
            {
                return false;
            }

            // contains at least one letter twice in a row
            if (!this.ContainsLetterPair(value))
            {
                return false;
            }

            if (this.ContainsInvalidPairs(value))
            {
                return false;
            }

            return true;
        }

        public bool IsNicePart2(string value)
        {
            // contains a unique letter pairs at least twice
            if (!this.ContainsLetterPairPair(value))
            {
                return false;
            }

            // contains two of the same letter , seperated by a different one
            if (!this.ContainsSplitLetterPair(value))
            {
                return false;
            }

            return true;
        }

        private bool ContainsLetterPairPair(string value)
        {
            var pairChars = new Dictionary<string, int>();
            
            for (int i = 1; i < value.Length; i++)
            {
                string pair = string.Format("{0}{1}", value[i], value[i - 1]);
                if (pairChars.ContainsKey(pair))
                {
                    if (pairChars[pair] < i - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    pairChars.Add(pair, i);
                }
            }

            return false;
        }

        private bool ContainsSplitLetterPair(string value)
        {
            for (int i = 2; i < value.Length; i++)
            {
                if (value[i].Equals(value[i - 2]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsInvalidPairs(string value)
        {
            var invalidPrefix = new[] { 'a', 'c', 'p', 'x' };
            for (int i = 1; i < value.Length; i++)
            {
                if (invalidPrefix.Contains(value[i - 1]) && value[i - 1] == value[i] - 1)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsLetterPair(string value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                if (value[i].Equals(value[i - 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsVowels(string value, char[] vowels)
        {
            return value.Count(c => vowels.Contains(c)) >= 3;
        }
    }
}