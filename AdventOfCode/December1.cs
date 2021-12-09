using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class December1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly int[] _measurements;

        public December1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var inputValues = File.ReadAllLines($"input/{GetType().Name.ToLower()}.txt");
            _measurements = inputValues.Select(int.Parse).ToArray();
        }

        [Fact]
        public void FirstStar()
        {
            var nrOfIncreasedMeasurements = 0;
            for (var i = 0; i < _measurements.Length - 1; i++)
            {
                if (_measurements[i] < _measurements[i + 1])
                {
                    nrOfIncreasedMeasurements++;
                }
            }

            _testOutputHelper.WriteLine($"Answer: {nrOfIncreasedMeasurements}");
            Assert.True(nrOfIncreasedMeasurements == 1624);
        }

        [Fact]
        public void SecondStar()
        {
            var nrOfIncreasedMeasurements = 0;
            var lastWindow = 0;
            for (var i = 0; i < _measurements.Length - 3; i++)
            {
                var nextWindow = _measurements[i] + _measurements[i + 1] + _measurements[i + 2];
                if (lastWindow < nextWindow)
                {
                    nrOfIncreasedMeasurements++;
                }

                lastWindow = nextWindow;
            }

            _testOutputHelper.WriteLine($"Answer: {nrOfIncreasedMeasurements}");
            Assert.True(nrOfIncreasedMeasurements == 1653);
        }
    }
}