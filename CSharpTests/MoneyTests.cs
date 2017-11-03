namespace CSharpTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Xunit;

    public class MoneyTestsShould
    {
        [Fact]
        public void LeaveUnchanged()
        {
            var input = new List<Tuple<string, decimal>>()
                            {
                                Tuple.Create("a", 1.99m),
                                Tuple.Create("b", 2.99m),
                                Tuple.Create("c", 1.00m),
                                Tuple.Create("d", 1.02m),
                            };
            var res = MoneyRounder.round(input);
            res.Sum(a => a.Item2).Should().Be(7m);
        }

        [Fact]
        public void KeepSum()
        {
            var input = new List<Tuple<string, decimal>>()
                            {
                                Tuple.Create("a", 1.5051m),
                                Tuple.Create("b", 2.5051m),
                                Tuple.Create("c", 1.5051m),
                                Tuple.Create("d", 1.4047m),
                            };
            var res = MoneyRounder.round(input);
            res.Sum(a => a.Item2).Should().Be(6.92m);
        }

        [Fact]
        public void KeepOrder()
        {
            var input = new List<Tuple<string, decimal>>()
                            {
                                Tuple.Create("a", 1.5051m),
                                Tuple.Create("b", 2.5051m),
                                Tuple.Create("c", 1.5051m),
                                Tuple.Create("d", 1.4047m),
                            };
            var res = MoneyRounder.round(input);
            res.ElementAt(0).Item1.ShouldBeEquivalentTo("a");
            res.ElementAt(1).Item1.ShouldBeEquivalentTo("b");
            res.ElementAt(2).Item1.ShouldBeEquivalentTo("c");
            res.ElementAt(3).Item1.ShouldBeEquivalentTo("d");
        }

        [Fact]
        public void CorrectResult()
        {
            var input = new List<Tuple<string, decimal>>()
                            {
                                Tuple.Create("a", 1.5051m),
                                Tuple.Create("b", 2.5051m),
                                Tuple.Create("c", 1.5051m),
                                Tuple.Create("d", 1.4047m),
                            };
            var res = MoneyRounder.round(input);
            res.ElementAt(0).Item2.Should().Be(1.51m);
            res.ElementAt(1).Item2.Should().Be(2.51m);
            res.ElementAt(2).Item2.Should().Be(1.50m);
            res.ElementAt(3).Item2.Should().Be(1.40m);
        }
    }
}