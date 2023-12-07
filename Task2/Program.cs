namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        List<Game> games = new List<Game>();
        string line = Console.ReadLine();
        while (line != "")
        {
            games.Add(new Game(line));
            line = Console.ReadLine();
        }
        Console.WriteLine(games.Sum(x => x.possible ? x.id : 0));
        Console.WriteLine(games.Sum(x => x.power));
        Console.WriteLine("Fnito");
    }
}


