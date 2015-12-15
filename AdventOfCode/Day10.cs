using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day10
    {
        //void Main()
        //{
        //    iterate(new[] { 1, 3, 2, 1, 1, 3, 1, 1, 1, 2 }, 50).Length.Dump();
        //}

        public int[] iterate(int[] data, int count)
        {
            if (count == 0) return data;

            List<int> result = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                var counter = 1;
                while (i < data.Length - 1 && data[i] == data[i + 1])
                {
                    counter++;
                    i++;
                }
                result.Add(counter);
                result.Add(data[i]);


            }
            return iterate(result.ToArray(), --count);
        }


        // Define other methods and classes here

    }
}
