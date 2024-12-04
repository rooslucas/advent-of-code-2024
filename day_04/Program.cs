using System;
using System.Text.RegularExpressions;

public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_04.txt";
        string[] parsed = Parse(file);
        Part1(parsed);
    }

    public static string[] Parse(string file) {
        // make all strings.
            // horizontal
        string[] horizontal = File.ReadAllLines(file);

            // vertical
        string[] text2 = File.ReadAllLines(file);
        char[][] matrix = text2.Select(x => x.ToCharArray()).ToArray();
        string[] vertical = new string[0];
        
        for(int i = 0; i < matrix[0].Count(); i++) {
            string temp = "";
            for(int j = 0; j < matrix.Count(); j++) {
                temp += matrix[j][i];
            }
            vertical = vertical.Concat(new string[] { temp }).ToArray();
        }

            // diagonal
        string[] diagonal = new string[0];

        for(int i = 3; i < matrix[0].Count(); i++) {
            string temp2 = "";
            for(int d=0; d<= i; d++){
                temp2 += matrix[0+d][i-d];

            }
            diagonal = diagonal.Concat(new string[] { temp2 }).ToArray();
        }
       
        for(int i = 1; i < matrix[0].Count(); i++) {
            string temp2 = "";
            int g = 0;
            for(int d=(matrix[0].Count() - 1); d >= i; d--){
                temp2 += matrix[g + i][d];
                g+=1;

            }
            diagonal = diagonal.Concat(new string[] { temp2 }).ToArray();        }

        for(int i = matrix[0].Count() - 2; i > 2; i--) {
            string temp2 = "";
            for(int d=0; d<= i; d++){
                temp2 += matrix[i-d][(matrix[0].Count() - 1) - d];

            }
            diagonal = diagonal.Concat(new string[] { temp2 }).ToArray();
        }

        for(int i = matrix[0].Count() - 1; i > 2; i--) {
            string temp2 = "";
            int g = 0;
            for(int d=(matrix[0].Count() - 1); d > (matrix[0].Count() - 2 - i); d--){
                temp2 += matrix[d][i - g];
                g+=1;
            }
            diagonal = diagonal.Concat(new string[] { temp2 }).ToArray();
        }

        string[] all = vertical.Concat(diagonal).ToArray();
        all = all.Concat(horizontal).ToArray();

        return all;
    }

    public static void Part1(string[] parsed) {

        int number = parsed.Select(x =>{
            Regex regexXmas = new Regex(@"XMAS");
            Regex regexSamx = new Regex(@"SAMX");
            var matches1 = regexXmas.Matches(x);

            var matches2 = regexSamx.Matches(x);

            return (matches1.Count() + matches2.Count());
        }).Sum();

        Console.WriteLine(number);
    }

        // for each string get matches
            // from xmas
            // from samx

        // string test = "MXMXAXMASAMX";

        // Regex regexXmas = new Regex(@"XMAS");
        // Regex regexSamx = new Regex(@"SAMX");
        // var matches1 = regexXmas.Matches(text);
        // foreach (var m in matches1){
        //     Console.WriteLine(m);
        // }

        // var matches2 = regexSamx.Matches(text);
        // foreach (var m in matches2){
        //     Console.WriteLine(m);
        // }
    
}