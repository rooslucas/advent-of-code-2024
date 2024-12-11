
public class Program
{
    public static void Main(string[] args)
    {
        string file = "./input/day_11.txt";
        List<string> stones = Parse(file);
        Part1(stones);
    }

    public static List<string> Parse(string file)
    {
        return File.ReadAllText(file).Split(' ').ToList();
    }

    public static void Part1(List<string> stones)
    {
        for (int i = 0; i < 25; i++)
        {
            // Console.WriteLine("New stones\n");

            int currentLength = stones.Count();
            for (int x = 0; x < currentLength; x++)
            {
                string stone = stones[x];
                if (Int64.Parse(stone) == 0) { stones[x] = "1"; }
                else if (stone.Count() % 2 == 0)
                {
                    if (stone.Count() > 2)
                    {
                        stones.Add(stone[0..(stone.Count() / 2)]);
                        stones[x] = Int64.Parse(stone[(stone.Count() / 2)..]).ToString();
                    }
                    else { stones.Add(stone[0].ToString()); stones[x] = (stone[1].ToString()); }
                }
                else { stones[x] = (Int64.Parse(stone) * 2024).ToString(); }
            }

            // foreach (string stone in stones) { Console.WriteLine(stone); }
            // Console.WriteLine(stones.Count());
        }

        Console.WriteLine(stones.Count());
    }
}