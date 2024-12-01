using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string file = "./input/day_01.txt"; 
        List<List<int>> parsed = parse(file);
        int result = solve(parsed[0], parsed[1]);
        Console.WriteLine(result);
    }

    public static List<List<int>> parse(string file)
    {
        string[] lines = File.ReadAllLines(file); 
        List<int> left_list = new List<int>();
        List<int> right_list = new List<int>();
        
        foreach(string line in lines)
        {
            List<string> num = line.Split(' ').ToList();

            num = num.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            int left_nur = Int32.Parse(num[0].Trim(' '));
            // Console.WriteLine(left_nur);
            int right_nur = Int32.Parse(num[1].Trim(' '));
            
            // Console.WriteLine(right_nur);

            left_list.Add(left_nur);
            right_list.Add(right_nur);
        }

        return new List<List<int>> { left_list, right_list };

    }

    public static int solve(List<int> left, List<int> right)
    {
        left.Sort();
        right.Sort();
        List<int> result = new List<int>();

        for(int i = 0; i < left.Count; i++){

            result.Add(Math.Abs(left[i] - right[i]));
        }

        return result.Sum();
    }
}