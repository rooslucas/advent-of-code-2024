using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string file = "./input/day_01.txt";
        var (parsed_l, parsed_r) = parse(file);
        int result_1 = solve_1(parsed_l, parsed_r);
        int result_2 = solve_2(parsed_l, parsed_r);
        Console.WriteLine(result_1);
        Console.WriteLine(result_2);
    }

    public static (List<int> Left, List<int> Right) parse(string file)
    {
        string[] lines = File.ReadAllLines(file);
        List<int> left_list = new List<int>();
        List<int> right_list = new List<int>();

        foreach (string line in lines)
        {
            List<string> num = line.Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            left_list.Add(Int32.Parse(num[0]));
            right_list.Add(Int32.Parse(num[1]));
        }

        return (left_list, right_list);
    }

    public static int solve_1(List<int> left, List<int> right)
    {
        left.Sort();
        right.Sort();
        return Enumerable.Range(0, left.Count).Select(i => Math.Abs(left[i] - right[i])).Sum();
    }

    public static int solve_2(List<int> left, List<int> right)
    {
        return Enumerable.Range(0, left.Count).Select(i => right.Where(x => x == left[i]).Count() * left[i]).Sum();
    }
}