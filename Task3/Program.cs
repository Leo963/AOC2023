string input = 
@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

// Split the input string by newline to get each row
string[] rows = input.Split('\n');

// Initialize a 2D array with the size of the grid
char[,] grid = new char[rows.Length, rows[0].Length];

// Iterate over each row
for (int i = 0; i < rows.Length; i++)
{
    // Iterate over each character in the row
    for (int j = 0; j < rows[i].Length; j++)
    {
        // Assign the character to the corresponding position in the grid
        grid[i, j] = rows[i][j];
    }
}

List<int> numbers = new List<int>();

// Iterate over each cell in the grid
for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 0; j < grid.GetLength(1); j++)
    {
        // If the cell is not a '.', check its surrounding cells
        if (grid[i, j] != '.' && !char.IsDigit(grid[i, j]))
        {
            // Iterate over the surrounding cells
            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    // Skip the cell itself
                    if (di == 0 && dj == 0)
                        continue;

                    // Calculate the coordinates of the surrounding cell
                    int ni = i + di;
                    int nj = j + dj;

                    // Check if the coordinates are inside the grid
                    if (ni >= 0 && ni < grid.GetLength(0) && nj >= 0 && nj < grid.GetLength(1))
                    {
                        // If the surrounding cell is a digit, extract the whole number
                        if (char.IsDigit(grid[ni, nj]))
                        {
                            // Calculate the coordinates of the opposite cell
                            int oi = i - di;
                            int oj = j - dj;

                            // If the opposite cell is inside the grid and is a digit, then it's not the start of the number, so skip it
                            if (oi >= 0 && oi < grid.GetLength(0) && oj >= 0 && oj < grid.GetLength(1) && char.IsDigit(grid[oi, oj]))
                                continue;

                            // Initialize the number and the multiplier
                            int number = 0;
                            int multiplier = 1;

                            // While the cell is a digit, add it to the number and move to the next cell in the direction of the number
                            while (ni >= 0 && ni < grid.GetLength(0) && nj >= 0 && nj < grid.GetLength(1) && char.IsDigit(grid[ni, nj]))
                            {
                                number += multiplier * int.Parse(grid[ni, nj].ToString());
                                multiplier *= 10;
                                ni += di;
                                nj += dj;
                            }

                            // Add the number to the list
                            numbers.Add(number);
                        }
                    }
                }
            }
        }
    }
}

foreach (var VARIABLE in numbers)
{
    Console.WriteLine(VARIABLE);
}
Console.WriteLine(numbers.Sum());
// Now the 'numbers' list contains all numbers that are next to a symbol other than '.'
