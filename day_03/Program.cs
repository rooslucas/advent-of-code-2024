using System;
using System.Text.RegularExpressions;

public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_03.txt";
        string lines = File.ReadAllText(file); 
        Console.WriteLine(Part1(lines));
        Console.WriteLine(Part2(lines));
    }

    public static int Part1(string lines) 
    {
        Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(lines);
        
        Regex numReg = new Regex(@"(\d+),(\d+)");

        int sum = matches.Select(x => {
            var numbers = numReg.Match(x.ToString()).ToString().Split(',');
            return Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
        }).Sum();

        return sum;
    }

    public static int Part2(string lines) 
    {
        Regex regex = new Regex(@"(mul\((\d+),(\d+)\))|(don't\(\))|(do\(\))");
        var matches2 = regex.Matches(lines);
        
        Regex numReg = new Regex(@"(\d+),(\d+)");
        bool enabled = true;

        int sum = matches2.Select( x => {
            if (x.ToString().Contains("don")) {enabled = false;}
            else if (x.ToString().Contains("do")) {enabled = true;}
            else if (enabled) {
                var numbers = numReg.Match(x.ToString()).ToString().Split(',');
                return Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
                }
            return 0;
        }).Sum();

        return sum;
    }
}