using System;

// Score entry data model - stores player's game results in Hall of Fame
public class ScoreEntry
{
    public string PlayerName { get; set; } = string.Empty;
    public Difficulty Difficulty { get; set; } = Difficulty.Easy;
    public int Attempts { get; set; }
    public double DurationSeconds { get; set; }
    public bool NewGamePlus { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public static ScoreEntry Create(string playerName, Difficulty difficulty, int attempts, double durationSeconds, bool newGamePlus)
    {
        return new ScoreEntry
        {
            PlayerName = playerName,
            Difficulty = difficulty,
            Attempts = attempts,
            DurationSeconds = durationSeconds,
            NewGamePlus = newGamePlus,
            Date = DateTime.UtcNow,
        };
    }
}
