using System;
using System.Linq;

namespace AdventOfCode;

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
    public int Gamma { get; private set; }
    public int Epsilon { get; private set; }

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

    public void Apply(Command[] commands)
    {
        foreach (var command in commands)
        {
            Apply(command);
        }
    }

    public void ReadDiagnostics(string[] inputValues)
    {
        string gamma = String.Empty;
        string epsilon = String.Empty;

        for (int i = 0; i < inputValues.First().Length; i++)
        {
            var bits = inputValues.Select(s => s[i]).GroupBy(c => int.Parse(c.ToString())).OrderByDescending(b => b.Count()).ToList();
            gamma += bits.First().Key.ToString();
            epsilon += bits.Last().Key.ToString();
        }

        Gamma = Convert.ToInt32(gamma, 2);
        Epsilon = Convert.ToInt32(epsilon, 2);
    }
}