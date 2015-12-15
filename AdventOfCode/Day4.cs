namespace AdventOfCode
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class Day4
    {
        private MD5 hasher;

        public Day4()
        {
        }

        public int FindHash(string key, string requiredPrefix = "00000")
        {
            using (this.hasher = MD5.Create())
            {
                key += "{0}";
                int iCount = -1;
                do
                {
                    iCount++;
                }
                while (!this.HashBeginsWith(string.Format(key, iCount),requiredPrefix));

                return iCount;
            }
        }
        

        private bool HashBeginsWith(string key, string prefix)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = this.hasher.ComputeHash(Encoding.UTF8.GetBytes(key));
            
            var stringBuilder = new StringBuilder();

            var iterationRequired = Math.Ceiling(prefix.Length / 2f);

            for (int i = 0; i < iterationRequired; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return stringBuilder.ToString().StartsWith(prefix);
        }
    }
}