var line = Console.ReadLine();
int totalCalib = 0;
while(line != "")
{
    Dictionary<string, KeyValuePair<int, char>> words = new Dictionary<string, KeyValuePair<int, char>>();
    words.Add("one", new KeyValuePair<int, char>(-1, '1'));
    words.Add("two", new KeyValuePair<int, char>(-1, '2'));
    words.Add("three", new KeyValuePair<int, char>(-1, '3'));
    words.Add("four", new KeyValuePair<int, char>(-1, '4'));
    words.Add("five", new KeyValuePair<int, char>(-1, '5'));
    words.Add("six", new KeyValuePair<int, char>(-1, '6'));
    words.Add("seven", new KeyValuePair<int, char>(-1, '7'));
    words.Add("eight", new KeyValuePair<int, char>(-1, '8'));
    words.Add("nine", new KeyValuePair<int, char>(-1, '9'));
    
    Dictionary<string, KeyValuePair<int, char>> wordsBack = new Dictionary<string, KeyValuePair<int, char>>();
    wordsBack.Add("one", new KeyValuePair<int, char>(-1, '1'));
    wordsBack.Add("two", new KeyValuePair<int, char>(-1, '2'));
    wordsBack.Add("three", new KeyValuePair<int, char>(-1, '3'));
    wordsBack.Add("four", new KeyValuePair<int, char>(-1, '4'));
    wordsBack.Add("five", new KeyValuePair<int, char>(-1, '5'));
    wordsBack.Add("six", new KeyValuePair<int, char>(-1, '6'));
    wordsBack.Add("seven", new KeyValuePair<int, char>(-1, '7'));
    wordsBack.Add("eight", new KeyValuePair<int, char>(-1, '8'));
    wordsBack.Add("nine", new KeyValuePair<int, char>(-1, '9'));
    
    foreach (var word in words)
    {
        if (line.Contains(word.Key))
        {
            words[word.Key] = new KeyValuePair<int, char>(line.IndexOf(word.Key),words[word.Key].Value);
            wordsBack[word.Key] = new KeyValuePair<int, char>(line.LastIndexOf(word.Key),wordsBack[word.Key].Value);
        }
    }
    char left = finaFromLeft(line);

    char finaFromLeft(string? s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                int left;
                try
                {
                    left = words.Where(x => x.Value.Key > -1).Select(x => x.Value.Key).Min();
                }
                catch (Exception e)
                {
                    left = int.MaxValue;
                }
                if (i < left)
                {
                    return s[i];
                }

                return words
                    .Where(x => x.Value.Key > -1)
                    .MinBy(x => x.Value.Key).Value.Value;
            }
        }
        return ' ';
    }

    char right = finaFromRight(line);

    char finaFromRight(string? s)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                int right;
                try
                {
                    right = wordsBack.Where(x => x.Value.Key > -1).Select(x => x.Value.Key).Max();
                }
                catch (Exception e)
                {
                    right = int.MinValue;
                }
                
                if (i > right)
                {
                    return s[i];
                }

                return wordsBack
                    .Where(x => x.Value.Key > -1)
                    .MaxBy(x => x.Value.Key).Value.Value;
            }
        }
        return ' ';
    }

    totalCalib += int.Parse(new string(new[] { left, right }));
    Console.WriteLine(int.Parse(new string(new[] { left, right })));
    line = Console.ReadLine();
}

Console.WriteLine(totalCalib);