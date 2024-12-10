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
        
        foreach(string line in lines)
        {
            List<string> num = line.Split(' ').ToList();

            num = num.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            int left_nur = Int32.Parse(num[0]);
            int right_nur = Int32.Parse(num[1]);

            left_list.Add(left_nur);
            right_list.Add(right_nur);
        }

        return (left_list, right_list);

    }

// part 1 solving
    public static int solve_1(List<int> left, List<int> right)
    {
        left.Sort();
        right.Sort();
        List<int> result = new List<int>();

        for(int i = 0; i < left.Count; i++){

            result.Add(Math.Abs(left[i] - right[i]));
        }

        return result.Sum();
    }

    public static int solve_2(List<int> left, List<int> right)
    {    
        List<int> result = new List<int>();
        for(int i = 0; i < left.Count; i++){
            int c = right.Where(x => x == left[i]).Count();
            result.Add(c * left[i]);
        }

        return result.Sum();
    }
}