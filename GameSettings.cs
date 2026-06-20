using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// Game settings - stores and manages user preferences (language, bet mode)
// Encapsulation
public class GameSettings
{
    public Language Language { get; set; } = Language.Polish;
    public bool AskBet { get; set; } = true;

    [JsonIgnore]
    private static string SettingsFileName => "settings.json";

    // Load settings from file
    public static GameSettings Load()
    {
        try
        {
            if (File.Exists(SettingsFileName))
            {
                string content = File.ReadAllText(SettingsFileName);
                var settings = JsonSerializer.Deserialize<GameSettings>(content);
                if (settings != null)
                {
                    return settings;
                }
            }
        }
        catch
        {
        }

        return new GameSettings();
    }

    // Save settings to file
    public void Save()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string content = JsonSerializer.Serialize(this, options);
            File.WriteAllText(SettingsFileName, content);
        }
        catch
        {
        }
    }
}
