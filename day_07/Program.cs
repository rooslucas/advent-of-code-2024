using System;

public class Program 
{
    public class Calculation {
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
        
    }

    public static List<Calculation> Parse(string file) {
        string[] text2 = File.ReadAllLines(file);
        List<Calculation> calculations = text2.Select(x => {
            string [] temp = x.Split(": ");
            List<string> tempNumbers = temp[1].Split(' ').ToList();
            return new Calculation(Int64.Parse(temp[0]), tempNumbers.Select(y => Int64.Parse(y)).ToList()); //fix sizing
        }).ToList();

        return calculations;
    }

    public static void Part1(List<Calculation> calculations) {
        long totalCorrect = calculations.Select(x => {

            long options = (long)Math.Pow(2, (x.numbers.Count()-1));

            for (int i = 0; i<options; i++) { 
                string bin = Convert.ToString(i, 2).PadLeft((x.numbers.Count()-1), '0');
                List<string> operators = bin.Select(x => {if (x=='1'){return "+";} else {return "*";}}).ToList();
                long accumulator = x.numbers[0];
                x.numbers.RemoveAt(0);

                List<(string, long)> opNums = operators.Zip(x.numbers, (l, n) => (l, n)).ToList();
                opNums.Insert(0, ("+", accumulator));
                x.numbers.Insert(0, accumulator);
                long result = opNums.Aggregate( (n1, n2) => {
                    long acc = 0;
                    if (n2.Item1 == "+"){ acc = n1.Item2+n2.Item2;} 
                    else { acc = n1.Item2*n2.Item2;} return("+", acc);}).Item2;
                if (result == x.total) {return x.total;}
            }
        
            return 0;
        }).Sum();

        Console.WriteLine(totalCorrect);
    }
}