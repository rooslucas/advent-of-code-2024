using System;
using System.Text.RegularExpressions;

public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_03.txt";
        Part1(file);
        Part2(file);
    }

    public static void Part1(string file) 
    {
        string lines = File.ReadAllText(file); 

        Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(lines);
        
        Regex numReg = new Regex(@"(\d+),(\d+)");

        int sum = matches.Select(x => {
            var numbers = numReg.Match(x.ToString()).ToString().Split(',');
            return Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
        }).Sum();

        Console.WriteLine(sum);
    }

        public static void Part2(string file) 
    {
        string lines = File.ReadAllText(file); 

        Regex regex = new Regex(@"(mul\((\d+),(\d+)\))|(don't\(\))|(do\(\))");
        var matches2 = regex.Matches(lines);
        
        Regex numReg = new Regex(@"(\d+),(\d+)");
        bool enabled = true;
        int sum = 0;

        foreach(var x in matches2) {
            if (x.ToString().Contains("don")) {enabled = false;}
            else if (x.ToString().Contains("do")) {enabled = true;}
            else if (enabled) {
                var numbers = numReg.Match(x.ToString()).ToString().Split(',');
                sum += Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
                }
        }

        Console.WriteLine(sum);
    }
}