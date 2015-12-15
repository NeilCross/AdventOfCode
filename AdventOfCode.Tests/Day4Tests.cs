namespace AdventOfCode.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class Day4Tests
    {
        private Day4 sut;

        private string puzzleInput;

        [SetUp]
        public void Setup()
        {
            this.sut = new Day4();
            
            this.puzzleInput = "bgvyzdsv";
        }

        [Test]
        public void Part1Examples()
        {
            Assert.AreEqual(609043, sut.FindHash("abcdef"));
            Assert.AreEqual(1048970, sut.FindHash("pqrstuv"));
        }

        [Test]
        public void Part1Result()
        {
            var result = sut.FindHash(this.puzzleInput);
            Trace.WriteLine("Result is " + result);
        }

        [Test]
        public void Part2Result()
        {
            var result = sut.FindHash(this.puzzleInput, "000000");
            Trace.WriteLine("Result is " + result);
        }
    }
}
