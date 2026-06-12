using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class HallOfFame
{
    private readonly List<ScoreEntry> entries = new();

    [JsonIgnore]
    private static string HallOfFameFileName => "halloffame.json";

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
    }

    public bool HasRecords => entries.Count > 0;

    public void Add(ScoreEntry entry)
    {
        entries.Add(entry);
    }

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
