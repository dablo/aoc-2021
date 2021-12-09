using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class December2
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Command[] _inputs;

        public December2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var inputValues = File.ReadAllLines($"input/{GetType().Name.ToLower()}.txt");
            _inputs = inputValues.Select(x => x.Split(' ')).Select(command => new Command(command.First(), int.Parse(command.Last()))).ToArray();
        }


        [Fact]
        public void FirstStar()
        {
            var sub = new Submarine();
            foreach (var command in _inputs)
            {
                sub.Apply(command);
            }

            _testOutputHelper.WriteLine($"Answer: {sub.Distance * sub.Aim}");
            Assert.True(sub.Distance * sub.Aim == 1648020);
        }

        [Fact]
        public void SecondStar()
        {
            var sub = new Submarine();
            foreach (var command in _inputs)
            {
                sub.Apply(command);
            }

            _testOutputHelper.WriteLine($"Answer: {sub.Distance * sub.Depth}");
            Assert.True(sub.Distance * sub.Depth == 0);
        }
    }

    public class Submarine
    {
        public Submarine()
        {
            Distance = 0;
            Depth = 0;
        }

        public int Distance { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }

        public void Apply(Command command)
        {
            switch (command.Name)
            {
                case "forward":
                    Distance += command.Value;
                    Depth += Aim * command.Value;
                    break;

                case "down":
                    Aim += command.Value;
                    break;

                case "up":
                    Aim -= command.Value;
                    break;

                default:
                    throw new Exception($"Invalid input: {command.Name} {command.Value}");
            }
        }
    }

    public record Command(string Name, int Value);
}