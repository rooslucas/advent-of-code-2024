using System;
using System.Globalization;

public class Program
{
    public class Calculation
    {
        public long total;
        public List<long> numbers;

        public Calculation(long total, List<long> numbers)
        {
            this.total = total;
            this.numbers = numbers;
        }
    }

    public static void Main(string[] args)
    {
        string file = "./input/day_07.txt";
        List<Calculation> parsed = Parse(file);
        Part1(parsed);
        Part2(parsed);

    }

    public static List<Calculation> Parse(string file)
    {
        string[] text2 = File.ReadAllLines(file);
        List<Calculation> calculations = text2.Select(x =>
        {
            string[] temp = x.Split(": ");
            List<string> tempNumbers = temp[1].Split(' ').ToList();
            return new Calculation(Int64.Parse(temp[0]), tempNumbers.Select(y => Int64.Parse(y)).ToList()); //fix sizing
        }).ToList();

        return calculations;
    }

    public static void Part1(List<Calculation> calculations)
    {
        long totalCorrect = calculations.Where(x =>
            Enumerable.Range(0, (int)Math.Pow(2, x.numbers.Count - 1))
                .Any(i =>
                    Convert.ToString(i, 2)
                    .PadLeft(x.numbers.Count() - 1, '0')
                    .Select(x => x == '1' ? "+" : "*")
                    .Zip(x.numbers.Skip(1), (l, n) => (l, n))
                    .Aggregate(x.numbers[0], (acc, x) => x.Item1 == "+" ? acc + x.Item2 : acc * x.Item2) == x.total
                )
        )
        .Select(calc => calc.total)
        .Sum();

        Console.WriteLine(totalCorrect);
    }

    public static void Part2(List<Calculation> calculations)
    {
        long totalCorrect = calculations.Where(x =>
            Enumerable.Range(0, (int)Math.Pow(3, x.numbers.Count - 1))
                .Any(i =>
                    ConvertBase3(i)
                    .PadLeft(x.numbers.Count() - 1, '0')
                    .Select(x => x == '1' ? "+" : (x == '0' ? "*" : "||"))
                    .Zip(x.numbers.Skip(1), (l, n) => (l, n))
                    .Aggregate(x.numbers[0], (acc, x) => x.Item1 == "+" ? acc + x.Item2 :
                    (x.Item1 == "*" ? acc * x.Item2 :
                    Int64.Parse(acc.ToString() + x.Item2.ToString()))) == x.total
                )
        )
        .Select(calc => calc.total)
        .Sum();

        Console.WriteLine(totalCorrect);
    }

    public static string ConvertBase3(long number)
    {
        if (number == 0)
            return "0";

        string result = "";
        while (number > 0)
        {
            long remainder = number % 3;
            result = remainder + result;
            number /= 3;
        }

        return result;
    }
}