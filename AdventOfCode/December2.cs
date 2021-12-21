using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class December2
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Submarine _sub;

        public December2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var inputValues = File.ReadAllLines($"input/{GetType().Name.ToLower()}.txt");
            var commands = inputValues.Select(x => x.Split(' ')).Select(command => new Command(command.First(), int.Parse(command.Last()))).ToArray();
            _sub = new Submarine();
            _sub.Apply(commands);
        }


        [Fact]
        public void FirstStar()
        {
            var answer = _sub.Distance * _sub.Aim;
            
            _testOutputHelper.WriteLine($"Answer: {answer}");
            
            Assert.True(answer == 1648020);
        }

        [Fact]
        public void SecondStar()
        {
            // What do you get if you multiply your final horizontal position by your final depth?
            var answer = _sub.Distance * _sub.Depth; 
            
            _testOutputHelper.WriteLine($"Answer: {answer}");
            
            // Answer
            Assert.True(answer == 1759818555);
        }
    }
}