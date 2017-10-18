namespace CSharpTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Xunit;

    public class Tests
    {
        [Fact]
        public void ShouldNotRound()
        {
            var data = new List<Tuple<string, decimal>>()
                           {
                               Tuple.Create("a", 25m),
                               Tuple.Create("b", 25m),
                               Tuple.Create("c", 25m),
                               Tuple.Create("d", 25m),
                           };

            var rounded = Rounder.round(data);

            rounded.First().Item1.Should().Be("a");
            rounded.ElementAt(1).Item1.Should().Be("b");
            rounded.ElementAt(2).Item1.Should().Be("c");
            rounded.ElementAt(3).Item1.Should().Be("d");

            rounded.First().Item2.Should().Be(25);
            rounded.ElementAt(1).Item2.Should().Be(25);
            rounded.ElementAt(2).Item2.Should().Be(25);
            rounded.ElementAt(3).Item2.Should().Be(25);
        }

        [Fact]
        public void ShouldRound()
        {
            var data = new List<Tuple<string, decimal>>()
                           {
                               Tuple.Create("a", 25.6m),
                               Tuple.Create("b", 25m),
                               Tuple.Create("c", 25m),
                               Tuple.Create("d", 24.4m),
                           };

            var rounded = Rounder.round(data);

            rounded.Sum(a => a.Item2).Should().Be(100);

            rounded.First().Item1.Should().Be("a");
            rounded.ElementAt(1).Item1.Should().Be("b");
            rounded.ElementAt(2).Item1.Should().Be("c");
            rounded.ElementAt(3).Item1.Should().Be("d");

            rounded.First().Item2.Should().Be(26);
            rounded.ElementAt(1).Item2.Should().Be(25);
            rounded.ElementAt(2).Item2.Should().Be(25);
            rounded.ElementAt(3).Item2.Should().Be(24);
        }

        [Fact]
        public void ShouldRound2()
        {
            var data = new List<Tuple<string, decimal>>()
                           {
                               Tuple.Create("a", 24.4m),
                               Tuple.Create("b", 25m),
                               Tuple.Create("c", 25m),
                               Tuple.Create("d", 25.6m),
                           };

            var rounded = Rounder.round(data);

            rounded.Sum(a => a.Item2).Should().Be(100);

            rounded.First().Item1.Should().Be("a");
            rounded.ElementAt(1).Item1.Should().Be("b");
            rounded.ElementAt(2).Item1.Should().Be("c");
            rounded.ElementAt(3).Item1.Should().Be("d");

            rounded.First().Item2.Should().Be(24);
            rounded.ElementAt(1).Item2.Should().Be(25);
            rounded.ElementAt(2).Item2.Should().Be(25);
            rounded.ElementAt(3).Item2.Should().Be(26);
        }

        [Fact]
        public void ShouldRoundTwoItems()
        {
            var data = new List<Tuple<string, decimal>>()
                           {
                               Tuple.Create("a", 25.6m),
                               Tuple.Create("b", 25.6m),
                               Tuple.Create("c", 24.4m),
                               Tuple.Create("d", 24.4m),
                           };

            var rounded = Rounder.round(data);

            rounded.Sum(a => a.Item2).Should().Be(100);

            rounded.First().Item1.Should().Be("a");
            rounded.ElementAt(1).Item1.Should().Be("b");
            rounded.ElementAt(2).Item1.Should().Be("c");
            rounded.ElementAt(3).Item1.Should().Be("d");

            rounded.First().Item2.Should().Be(26);
            rounded.ElementAt(1).Item2.Should().Be(26);
            rounded.ElementAt(2).Item2.Should().Be(24);
            rounded.ElementAt(3).Item2.Should().Be(24);
        }

        [Fact]
        public void ShouldRoundSome()
        {
            var data = new List<Tuple<string, decimal>>()
                           {
                               Tuple.Create("Equities", 31.6220989654932m),
                               Tuple.Create("Fixed Income", 55.8340786306896m),
                               Tuple.Create("Alternatives", 2.88033373820556m),
                               Tuple.Create("Cash", 9.66349214560435m),
                           };

            var rounded = Rounder.round(data);

            rounded.Sum(a => a.Item2).Should().Be(100);

            rounded.First().Item1.Should().Be("Equities");
            rounded.ElementAt(1).Item1.Should().Be("Fixed Income");
            rounded.ElementAt(2).Item1.Should().Be("Alternatives");
            rounded.ElementAt(3).Item1.Should().Be("Cash");

            rounded.First().Item2.Should().Be(31);
            rounded.ElementAt(1).Item2.Should().Be(56);
            rounded.ElementAt(2).Item2.Should().Be(3);
            rounded.ElementAt(3).Item2.Should().Be(10);
        }

        ////[Fact]
        ////public void ShouldRoundDouble()
        ////{
        ////    var data = new List<Tuple<string, double>>()
        ////                   {
        ////                       Tuple.Create("a", 24.4),
        ////                       Tuple.Create("b", 25.0),
        ////                       Tuple.Create("c", 25.0),
        ////                       Tuple.Create("d", 25.6),
        ////                   };

        ////    var rounded = Rounder.round(data);

        ////    rounded.Sum(a => a.Item2).Should().Be(100);

        ////    rounded.First().Item1.Should().Be("a");
        ////    rounded.ElementAt(1).Item1.Should().Be("b");
        ////    rounded.ElementAt(2).Item1.Should().Be("c");
        ////    rounded.ElementAt(3).Item1.Should().Be("d");

        ////    rounded.First().Item2.Should().Be(24);
        ////    rounded.ElementAt(1).Item2.Should().Be(25);
        ////    rounded.ElementAt(2).Item2.Should().Be(25);
        ////    rounded.ElementAt(3).Item2.Should().Be(26);
        ////}
    }
}
