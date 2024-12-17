
public class Program
{
    public static void Main(string[] args)
    {
        string file = "./input/day_02.txt";
        SolvingPart1(Parse(file));
        SolvingPart2(Parse(file));

    }

    public static List<List<int>> Parse(string file)
    {
        return File.ReadAllLines(file)
            .Select(x => x.Split(' '))
            .Select(x => x.Select(y => Int32.Parse(y)).ToList())
            .ToList();

    }

    public static void SolvingPart1(List<List<int>> parsed)
    {
        int safe = parsed.Select(x =>
        ValidList(x)).Sum();

        Console.WriteLine(safe);
    }

    public static void SolvingPart2(List<List<int>> parsed)
    {
        int safe = parsed.Select(x => ValidList(x) == 1 ? 1 :
            (Enumerable.Range(0, x.Count)
                .Where(i => ValidList(SkipAt(x, i)) == 1)
                .Count() > 0 ? 1 : 0)).Sum();

        Console.WriteLine(safe);

    }

    public static int ValidList(List<int> t)
    {

        bool asc = (t[0] - t[1]) > 0;
        bool desc = (t[0] - t[1]) < 0;

        int r = Enumerable.Range(0, t.Count - 1).Select(i =>
        {
            if (desc) { return ((t[i] - t[i + 1]) >= -3) && ((t[i] - t[i + 1]) < 0) ? 1 : 0; }
            else if (asc) { return ((t[i] - t[i + 1]) <= 3) && ((t[i] - t[i + 1]) > 0) ? 1 : 0; }
            return 0;
        }).Sum();

        return r == (t.Count - 1) ? 1 : 0;
    }

    public static List<int> SkipAt(List<int> source, int indexToSkip)
    {
        return source.Where((value, index) => index != indexToSkip).ToList();
    }

}