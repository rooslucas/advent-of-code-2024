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
        long totalCorrect = calculations.Select(x =>
        {

            long options = (long)Math.Pow(2, (x.numbers.Count() - 1));

            for (int i = 0; i < options; i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft(x.numbers.Count() - 1, '0');
                List<string> operators = bin.Select(x => x == '1' ? "+" : "*").ToList();

                List<(string, long)> opNums = operators.Zip(x.numbers.Skip(1), (l, n) => (l, n)).ToList();

                long result = opNums.Aggregate(x.numbers[0], (acc, x) => x.Item1 == "+" ? acc + x.Item2 : acc * x.Item2);

                // x.numbers.Insert(0, accumulator);
                if (result == x.total) { return x.total; }
            }

            return 0;
        }).Sum();

        Console.WriteLine(totalCorrect);
    }

    public static void Part2(List<Calculation> calculations)
    {
        long totalCorrect = calculations.Select(x =>
        {

            long options = (long)Math.Pow(3, (x.numbers.Count() - 1));

            for (int i = 0; i < options; i++)
            {
                string bin = ConvertBase3(i).PadLeft(x.numbers.Count() - 1, '0');
                // Console.WriteLine(bin);
                List<string> operators = bin.Select(x => { if (x == '1') { return "+"; } else if (x == '0') { return "*"; } else { return "||"; } }).ToList();
                long accumulator = x.numbers[0];
                x.numbers.RemoveAt(0);

                List<(string, long)> opNums = operators.Zip(x.numbers, (l, n) => (l, n)).ToList();
                opNums.Insert(0, ("+", accumulator));
                x.numbers.Insert(0, accumulator);
                long result = opNums.Aggregate((n1, n2) =>
                {
                    long acc = 0;
                    if (n2.Item1 == "+") { acc = n1.Item2 + n2.Item2; }
                    else if (n2.Item1 == "*") { acc = n1.Item2 * n2.Item2; }
                    else { acc = Int64.Parse(n1.Item2.ToString() + n2.Item2.ToString()); }
                    return ("+", acc);
                }).Item2;

                // Console.WriteLine(result);
                if (result == x.total) { return x.total; }
            }

            return 0;
        }).Sum();

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