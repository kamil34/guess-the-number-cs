using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

// Hall of Fame - manages player scores and rankings
public class HallOfFame
{
    private List<ScoreEntry> entries = new();

    [JsonPropertyName("entries")]
    public List<ScoreEntry> Entries
    {
        get => entries;
        set => entries = value ?? new();
    }

    [JsonIgnore]
    private static string HallOfFameFileName => "halloffame.json";

    // Load from JSON file
    public static HallOfFame Load()
    {
        try
        {
            if (File.Exists(HallOfFameFileName))
            {
                string content = File.ReadAllText(HallOfFameFileName);
                var loaded = JsonSerializer.Deserialize<HallOfFame>(content);
                if (loaded != null)
                {
                    return loaded;
                }
            }
        }
        catch
        {
        }

        return new HallOfFame();
    }

    // Save to file
    public void Save()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string content = JsonSerializer.Serialize(this, options);
            File.WriteAllText(HallOfFameFileName, content);
        }
        catch
        {
        }

        SaveToText();
    }

    // Save to text file
    private void SaveToText()
    {
        try
        {
            var lines = new List<string> { "HALL OF FAME - SCORES", "==================", "" };
            
            var difficulties = new[] { Difficulty.Easy, Difficulty.Medium, Difficulty.Hard };
            
            foreach (var difficulty in difficulties)
            {
                var topScores = GetTopForDifficulty(difficulty, int.MaxValue);
                
                if (topScores.Count == 0)
                {
                    continue;
                }
                
                lines.Add($"{difficulty} Difficulty:");
                lines.Add(new string('-', 50));
                
                for (int index = 0; index < topScores.Count; index++)
                {
                    var entry = topScores[index];
                    string ngpMarker = entry.NewGamePlus ? " [NG+]" : "";
                    lines.Add($"{index + 1}. {entry.PlayerName} - {entry.Attempts} attempts - {entry.DurationSeconds:F1}s - {entry.Date:yyyy-MM-dd HH:mm:ss}{ngpMarker}");
                }
                
                lines.Add("");
            }
            
            File.WriteAllLines("scores.txt", lines);
        }
        catch
        {
        }
    }

    // Record operations
    public bool HasRecords => entries.Count > 0;

    public void Add(ScoreEntry entry)
    {
        entries.Add(entry);
    }

    // Get top scores for difficulty
    public List<ScoreEntry> GetTopForDifficulty(Difficulty difficulty, int topCount)
    {
        return entries
            .Where(entry => entry.Difficulty == difficulty)
            .OrderBy(entry => entry.Attempts)
            .ThenBy(entry => entry.DurationSeconds)
            .ThenBy(entry => entry.Date)
            .Take(topCount)
            .ToList();
    }

    // Clear records
    public void Clear()
    {
        entries.Clear();
        try
        {
            if (File.Exists(HallOfFameFileName))
            {
                File.Delete(HallOfFameFileName);
            }
        }
        catch
        {
        }
    }
}
