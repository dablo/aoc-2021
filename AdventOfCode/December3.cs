using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode;

public class December3
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Submarine _sub;

    public December3(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var inputValues = File.ReadAllLines($"input/{GetType().Name.ToLower()}.txt");
        _sub = new Submarine();
        _sub.ReadDiagnostics(inputValues);
    }


    [Fact]
    public void FirstStar()
    {
        var answer = _sub.Gamma * _sub.Epsilon;

        _testOutputHelper.WriteLine($"Answer: {answer}");

        Assert.True(answer == 3958484);
    }

    [Fact]
    public void SecondStar()
    {
        // What do you get if you multiply your final horizontal position by your final depth?
        var answer = _sub.Gamma * _sub.Epsilon;

        _testOutputHelper.WriteLine($"Answer: {answer}");

        // Answer
        Assert.True(answer == 0);
    }
}