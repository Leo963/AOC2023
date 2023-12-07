namespace Task2;

public class Game
{
    private const int MAX_RED = 12;
    private const int MAX_GREEN = 13;
    private const int MAX_BLUE = 14;
    public int id { get; }
    private List<CubeSet> sets { get; }
    private CubeSet minSet;
    
    public int power { get; }

    public bool possible { get; }
    
    public Game(int id)
    {
        this.id = id;
        this.sets = new List<CubeSet>();
    }

    public Game(string input)
    {
        id = int.Parse(input.Split(" ")[1].Substring(0, input.Split(" ")[1].Length - 1));
        sets = CubeSet.parseSets(input.Split(":")[1].Trim());
        if (sets.Any(x => x.green > MAX_GREEN || x.red > MAX_RED || x.blue > MAX_BLUE))
        {
            possible = false;
        }
        else
        {
            possible = true;
        }

        minSet = new CubeSet(
            sets.Max(x => x.red),
            sets.Max(x => x.green),
            sets.Max(x => x.blue)
        );
        power = minSet.red * minSet.green * minSet.blue;
    }
}