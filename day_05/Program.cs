public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_05.txt";
        (Number[], string[]) output = Parse(file);
        Part1(output.Item1, output.Item2);
    }

    public class Number {
        public int number1;
        public int number2;

        public Number(int number1, int number2)
        {
            this.number1 = number1;
            this.number2 = number2;
        }
    }

    public static (Number[], string[]) Parse(string file) {
        string[] input = File.ReadAllLines(file);
        int indexSplit = 0;

        for(int i = 0; i<input.Count(); i++) {
            if(input[i]=="") {
                 indexSplit = i;
            }
        }

        // string[] rules = input.Take(indexSplit).ToArray();
        string[] tempRules = input[0..indexSplit];
        string[] updates = input[(indexSplit+1)..^0];

        Number[] rules = tempRules.Select(x => {
            string[] spl= x.Split('|');
            return new Number(Int32.Parse(spl[0]),Int32.Parse(spl[1]));
            }).ToArray();

        // foreach(string rule in updates) {
        //     Console.WriteLine(rule);
        // }

        return (rules, updates);
    }

    public static void Part1(Number[] rules, string[] updates){
        int middlePageSum = updates.Select(x => {
            string[] tempNums = x.Split(',');
            List<int> nums = tempNums.Select(x => Int32.Parse(x)).ToList();
            int middle = nums[(nums.Count()/2)];
            
            for(int n=0; n < nums.Count(); n++) {
                List<int> relevant = rules.Select(x => {if (x.number2 == nums[n]) {return x.number1;} return 0;}).ToList();

                nums.Remove(nums[n]);

                int check = nums.Select(x => {if(relevant.Contains(x)) {return 0;} return 1;}).Sum();

                if (check <= (nums.Count - 1)) {return 0;}
                if (nums.Count() > 1)
                    {n--;}
            }

            Console.WriteLine(middle);
            return middle;
        }).Sum();

        Console.WriteLine(middlePageSum);
    }
}

