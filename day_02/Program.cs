
public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_02.txt";
        SolvingPart1(Parse(file));
        SolvingPart2(Parse(file));

    }

    public static IEnumerable<int>[] Parse(string file) 
    {
        string[] lines = File.ReadAllLines(file); 
        var split = lines.Select(x => x.Split(' '));
        IEnumerable<int>[] parsed = split.Select(x => x.Select(y => Int32.Parse(y))).ToArray();

        return parsed;

    }

    public static void SolvingPart1(IEnumerable<int>[] parsed) 
    {
        int safe = parsed.Select( x => {
        
        var t = x.ToList();
        return ValidList(t);
        }).ToList().Sum();

        Console.WriteLine(safe);
    }

    public static void SolvingPart2(IEnumerable<int>[] parsed)
    {
        int safe = parsed.Select( x => {
            List<int> t = x.ToList();

            if (ValidList(t) == 0){

                for(int i = 0; i < x.Count(); i++) {
                    List<int> q = x.ToList();
                    q.RemoveAt(i);
                    if (ValidList(q) == 1){
                        return 1;}
                    
                }
            }
            else { return 1;}
            return 0;
        }).ToList().Sum();

        Console.WriteLine(safe);
        
    }

    public static int ValidList(List<int> t){
        int r = 0;
        bool asc = false;
        bool desc = false;

        if((t[0] - t[1]) > 0) {asc = true;}
        else if((t[0] - t[1]) < 0) {desc = true;}
        else{return 0;}

        for(int i = 0; i < t.Count() - 1; i++) {

            if (desc) {
                if(((t[i] - t[i+1]) >= -3) && ((t[i] - t[i+1]) < 0)) {
                    r += 1;}
                else {return 0;}
                }
            
            else if (asc) {
                if(((t[i] - t[i+1]) <= 3) && ((t[i] - t[i+1]) > 0)) {
                    r += 1;}
                else {return 0;}
                }
            else {return 0;}
 

        }
        return 1;
    }

}