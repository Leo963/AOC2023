namespace Task2;

public class CubeSet
{
    public static List<CubeSet> parseSets(string input)
    {
        List<CubeSet> sets = new List<CubeSet>();
        foreach (string set in input.Split(";"))
        {
            sets.Add(new CubeSet(set.Trim()));
        }
        return sets;
    }
    
    public int red { get; }
    public int green { get; }
    public int blue { get; }
    
    public CubeSet(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }
    
    public CubeSet(string input)
    {
        string[] cubes = input.Split(",");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = cubes[i].Trim();
        }
        
        foreach (string cube in cubes)
        {
            switch (cube.Split(" ")[1])
            {
                case "red":
                    red = int.Parse(cube.Split(" ")[0]);
                    break;
                case "green":
                    green = int.Parse(cube.Split(" ")[0]);
                    break;
                case "blue":
                    blue = int.Parse(cube.Split(" ")[0]);
                    break;
            }
        }
    }
}