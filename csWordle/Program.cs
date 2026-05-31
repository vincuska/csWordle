List<string> words = new List<string>(File.ReadAllLines("words.txt").Select(word => word.Trim().ToLowerInvariant()));

Random rand = new Random();

string answer = words[rand.Next(words.Count)];

Console.WriteLine("Wordle! Guess the word in 6 tries.");

int maxAttempts = 6;

int attempt = 0;
List<string> guesses = new List<string>();
bool won = false;

while (attempt < maxAttempts)
{
    RenderBoard(maxAttempts - attempt);
    Console.Write("> ");
    string? guess = Console.ReadLine()?.Trim().ToLowerInvariant();

    if (guess == null || guess.Length != answer.Length || !words.Contains(guess))
    {
        continue;
    }

    attempt++;
    guesses.Add(guess);

    if (guess == answer)
    {
        RenderBoard(maxAttempts - attempt);
        Console.WriteLine("You won!");
        won = true;
        break;
    }
}

if (!won)
{
    RenderBoard(maxAttempts - attempt);
    Console.WriteLine($"You lost! The word was: {answer}");
}

Console.Write("\nPress enter to quit...");
Console.ReadLine();

void RenderBoard(int guessesLeft)
{
    Console.Clear();
    Console.WriteLine($"Wordle! Guess the word in {guessesLeft} tries.");

    foreach (string pastGuess in guesses)
    {
        PrintGuess(pastGuess, answer);
    }
}

static void PrintGuess(string guess, string answer)
{
    char[] answerChars = answer.ToCharArray();
    char[] guessChars = guess.ToCharArray();
    ConsoleColor[] colors = new ConsoleColor[guessChars.Length];

    for (int i = 0; i < guessChars.Length; i++)
    {
        if (guessChars[i] == answerChars[i])
        {
            colors[i] = ConsoleColor.Green;
            answerChars[i] = '\0';
            guessChars[i] = '\0';
        }
    }

    for (int i = 0; i < guessChars.Length; i++)
    {
        if (guessChars[i] == '\0')
        {
            continue;
        }

        int matchIndex = Array.IndexOf(answerChars, guessChars[i]);
        if (matchIndex >= 0)
        {
            colors[i] = ConsoleColor.DarkYellow;
            answerChars[matchIndex] = '\0';
        }
        else
        {
            colors[i] = ConsoleColor.Gray;
        }
    }

    for (int i = 0; i < guess.Length; i++)
    {
        Console.ForegroundColor = colors[i];
        Console.Write(guess[i]);
    }

    Console.ResetColor();
    Console.WriteLine();
}
