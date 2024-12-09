public class Program 
{
    public static void Main(string[] args)
    {
        string file = "./input/day_06.txt";
        (char[][], int, int) parsed = Parse(file); 
        Part1(parsed.Item1, parsed.Item2, parsed.Item3);
    }

    public static (char[][], int, int) Parse(string file) {
        string[] text2 = File.ReadAllLines(file);
        int row = 0;
        int column = 0;
        char[][] matrix = text2.Select(x => {
            if(x.Contains('^')){row = Array.FindIndex(text2, y => y.Contains('^'));;
            column = x.IndexOf('^');} 
            return x.ToCharArray();}).ToArray();
        return (matrix, row, column);
    }

    public static void Part1(char[][] matrix, int startRow, int startColumn) {
        int x = startRow;
        int y = startColumn;
        int counter = -1;
        string direction = "U";
        while((x >= 0) && (x < matrix[0].Count()) && (y >= 0) && (y < matrix.Count()))
        {
            if(matrix[x][y] != '#'){
                matrix[x][y] = 'X';
                if ((direction == "U") || (direction == "D")){
                    x += counter;
                }
                else {
                    y += counter;
                }
            }
            else {
                if(direction =="U"){direction = "R"; x-=counter; counter *= -1;}
                else if(direction =="R"){direction = "D"; y-=counter;}
                else if(direction =="D"){direction = "L"; x-=counter; counter *= -1;}
                else {direction = "U"; y -=counter;}
                
            }
        }

        int totalX = matrix.Select(x => x.Where(y => y == 'X').Count()).Sum();

        Console.WriteLine(totalX);
    }


}