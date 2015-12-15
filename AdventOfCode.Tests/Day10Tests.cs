namespace AdventOfCode.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class Day10Tests
    {
        private Day10 sut;

        private int[] puzzleInput;

        [SetUp]
        public void Setup()
        {
            this.sut = new Day10();

            this.puzzleInput = new[] { 1, 3, 2, 1, 1, 3, 1, 1, 1, 2 };
        }

        [Test]
        public void Part1Examples()
        {
            Assert.AreEqual(new[] { 1, 1 }, sut.Iterate(new[] { 1 }, 1));
            Assert.AreEqual(new[] { 2, 1 }, sut.Iterate(new[] { 1, 1 }, 1));
            Assert.AreEqual(new[] { 1, 2, 1, 1 }, sut.Iterate(new[] { 2, 1 }, 1));
            Assert.AreEqual(new[] { 1, 1, 1, 2, 2, 1 }, sut.Iterate(new[] { 1, 2, 1, 1 }, 1));
            Assert.AreEqual(new[] { 3, 1, 2, 2, 1, 1 }, sut.Iterate(new[] { 1, 1, 1, 2, 2, 1 }, 1));
        }

        [Test]
        public void Part1Result()
        {
            var result = sut.Iterate(this.puzzleInput, 40).Length;
            Trace.WriteLine("Result is " + result);
        }

        [Test]
        public void Part2Result()
        {
            var result = sut.Iterate(this.puzzleInput, 50).Length;
            Trace.WriteLine("Result is " + result);
        }
}
}
