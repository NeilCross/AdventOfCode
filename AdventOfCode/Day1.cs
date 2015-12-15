namespace AdventOfCode
{
    using System.Linq;

    /// <summary>
    /// </summary>
    public class Day1
    {
        /// <summary>
        /// </summary>
        /// <param name="instructions">
        /// </param>
        /// <returns>
        /// </returns>
        public int Follow(string instructions) 
        {
            var steps = instructions.ToCharArray();
            return steps.Count(s => s.Equals('(')) - steps.Count(s => s.Equals(')'));
        }

        public int followTo(string instructions, int levelRequired)
        {
            return followTo(instructions, 0, 0, levelRequired);
        }

        private int followTo(string instructions, int pointer, int currentLevel, int levelRequired)
        {
            if (currentLevel == levelRequired)
            {
                return pointer;
            }

            if (instructions[pointer] == '(')
            {
                currentLevel++;
            }
            else if (instructions[pointer] == ')')
            {
                currentLevel--;
            }

            pointer++;

            return this.followTo(instructions, pointer, currentLevel, levelRequired);
        }

        // Define other methods and classes here
    }
}