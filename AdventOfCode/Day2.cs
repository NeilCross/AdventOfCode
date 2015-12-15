using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day2
    {
        public int Wrap(IEnumerable<IEnumerable<int>> input)
        {
            int total = 0;
            foreach (var item in input)
            {
                var size = 2 * item.ElementAt(0) * item.ElementAt(1) +
                2 * item.ElementAt(1) * item.ElementAt(2) +
                2 * item.ElementAt(0) * item.ElementAt(2);

                var smallest = this.GetSmallest(item);

                size += smallest[0] * smallest[1];

                total += size;
            }
            return total;
        }

        public int[] GetSmallest(IEnumerable<int> item)
        {

            int x, y;

            x = item.ElementAt(0);
            y = item.ElementAt(1);
            var comp = item.ElementAt(2);
            if (comp < x)
            {
                comp = x;
                x = item.ElementAt(2);
            }
            if (comp < y)
            {
                y = comp;
            }
            return new[] { x, y };
        }

        public int Ribbon(IEnumerable<IEnumerable<int>> input)
        {
            int total = 0;
            foreach (var item in input)
            {
                var length = item.ElementAt(0) * item.ElementAt(1) * item.ElementAt(2);

                var smallest = this.GetSmallest(item);

                length += (smallest[0] + smallest[1]) * 2;
                total += length;
            }
            return total;
        }
    }
}
