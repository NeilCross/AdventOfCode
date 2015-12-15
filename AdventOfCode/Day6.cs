namespace AdventOfCode
{
    using System;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Messaging;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public class Day6
    {
        private readonly int gridWidth;

        private readonly int gridHeight;

        private readonly int[,] grid;
        
        public Day6(int gridWidth, int gridHeight)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            this.grid = new int[this.gridWidth, this.gridHeight];
        }

        public int TotalLights
        {
            get
            {
                var counter = 0;
                foreach (var b in grid)
                {
                    if (b > 0)
                    {
                        counter++;
                    }
                }

                return counter;
            }
        }

        public int TotalBrightness
        {
            get
            {
                return this.grid.Cast<int>().Aggregate((i, i1) => i + i1);
            }
        }

        public void ProcessingInstructionPart1(string operation, int x1, int y1, int x2, int y2)
        {
            Func<int, int> f = b => b;

            switch (operation)
            {
                case "turn off":
                    f = b => 0;
                    break;
                case "turn on":
                    f = b => 1;
                    break;
                case "toggle":
                    f = b => b == 0 ? 1 : 0;
                    break;
            }

            for (int x = x1; x <= x2; x++)
            {

                for (int y = y1; y <= y2; y++)
                {
                    grid[x, y] = f(grid[x, y]);
                }
            }
        }


        public void ProcessingInstructionPart2(string operation, int x1, int y1, int x2, int y2)
        {
            Func<int, int> f = b => b;

            switch (operation)
            {
                case "turn off":
                    f = b => b - 1 < 0 ? 0 : b - 1;
                    break;
                case "turn on":
                    f = b => b + 1;
                    break;
                case "toggle":
                    f = b => b + 2;
                    break;
            }

            for (int x = x1; x <= x2; x++)
            {

                for (int y = y1; y <= y2; y++)
                {
                    grid[x, y] = f(grid[x, y]);
                }
            }
        }

        public void ProcessInstructions(Action<string, int, int, int, int> func, string[] instructionStrings)
        {
            var regex = @"(.*) ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)";
            var instructionRegex = new Regex(@"(.*) ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)");
            foreach (var instruction in instructionStrings)
            {
                var result = instructionRegex.Match(instruction);
                var verb = result.Groups[1].Value;
                var x1 = Convert.ToInt32(result.Groups[2].Value);
                var y1 = Convert.ToInt32(result.Groups[3].Value);
                var x2 = Convert.ToInt32(result.Groups[4].Value);
                var y2 = Convert.ToInt32(result.Groups[5].Value);
                func(verb, x1, y1, x2, y2);
            }
        }

        public void ProcessInstructionsPart1(string[] instructionStrings)
        {
            this.ProcessInstructions(this.ProcessingInstructionPart1, instructionStrings);
        }

        public void ProcessInstructionsPart2(string[] instructionStrings)
        {
            this.ProcessInstructions(this.ProcessingInstructionPart2, instructionStrings);
        }
    }
}