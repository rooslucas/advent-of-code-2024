
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
        int r = 0;
        bool asc = false;
        bool desc = false;

        if((t[0] - t[1]) > 0) {asc = true;}
        else if((t[0] - t[1]) < 0) {desc = true;}
        else{return 0;}

        for(int i = 0; i < x.Count() - 1; i++) {

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
        }).ToList().Sum();

        Console.WriteLine(safe);
    }

    public static void SolvingPart2(IEnumerable<int>[] parsed) 
    {
        int safe = parsed.Select( x => {
        
        var t = x.ToList();
        int r = 0;
        bool asc = false;
        bool desc = false;
        bool flag = true;

        if((t[1] - t[0]) > 0) {asc = true;}
        else if((t[1] - t[0]) < 0) {desc = true;}

        for(int i = 0; i < t.Count() - 1; i++) {
            //Console.WriteLine("new");
            if (desc) {
                if(((t[i] - t[i+1]) <= 3) && ((t[i] - t[i+1]) > 0))  {
                    r += 1;}
                
                else if (flag){
                //Console.WriteLine(t[i]);

                    if((i+2) <= (t.Count()-1)){
                        if((t[i+1] - t[i])> 0) {t.RemoveAt(i-1);} 
                        else if((Math.Abs(t[i] - t[i+2]) <= 3) && (Math.Abs(t[i] - t[i+2]) > 0)){t.RemoveAt(i+1);}
                        else{t.RemoveAt(i);}}
                    else{t.RemoveAt(i);}
                    
                    i = -1;
                    r = 0; 
                    flag = false;

                    if((t[1] - t[0]) > 0) {asc = true; desc=false;}
                    else if((t[1] - t[0]) < 0) {desc = true; asc=true;}
                    
                }
                
                // else {return 0;}
            }
            
            else if (asc) {
                if(((t[i] - t[i+1]) >= -3) && ((t[i] - t[i+1]) < 0)) {
                    r += 1;}
                
                else if (flag){
                    //Console.WriteLine(t[i]);

                    if((i+2) <= (t.Count()-1)){
                        if(((t[i+1] - t[i])< 0) && (t[i+2] - t[i+1])< 0) {t.RemoveAt(i-1);}
                        else if((Math.Abs(t[i] - t[i+2]) <= 3) && (Math.Abs(t[i] - t[i+2]) > 0)){t.RemoveAt(i+1);}
                        else{t.RemoveAt(i);}
                        }
                    
                    else if((Math.Abs(t[i-1] - t[i]) <= 3) && (Math.Abs(t[i-1] - t[i]) > 0)){t.RemoveAt(i+1);}
                    else{t.RemoveAt(i);}
                    
                    i = -1;
                    r = 0;
                    flag = false;
                    if((t[1] - t[0]) > 0) {asc = true; desc=false;}
                    else if((t[1] - t[0]) < 0) {desc = true; asc=true;}}
                
                // else { return 0;}
                }
                
                //Console.WriteLine(asc);
            
 
        }

        if(r == (t.Count()-1)) 
        
        {return 1;}
        
        Console.WriteLine((t[0], t[1], t[2], t[3]).ToString());
        return 0;
        }).ToList().Sum();

        Console.WriteLine(safe);
    }

}