List<string> words = new List<string>(File.ReadAllLines("words.txt"));

Random rand = new Random();

string answer = words[rand.Next(words.Count)];

Console.WriteLine(answer);

int maxAttempts = 6;

int attempt = 0;

Console.Write("> ");
string? guess = Console.ReadLine();

while (guess != null && guess != answer && attempt < maxAttempts - 1)
{
    if (guess.Length != answer.Length)
    {
        Console.WriteLine($"\nGuess must be {answer.Length} letters long.");
    }
    else if (!words.Contains(guess))
    {
        Console.WriteLine("\nInvalid word.");
    }
    else
    {
        attempt++;
        Console.WriteLine($"\n{maxAttempts - attempt} attempts remaining.");
    }

    Console.Write("> ");
    guess = Console.ReadLine();
}

if (guess == answer)
{
    Console.WriteLine("\nYou won!");
}
else
{
    Console.WriteLine($"\nYou lost! The word was: {answer}");
}