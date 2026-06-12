using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GameSettings
{
    public Language Language { get; set; } = Language.Polish;
    public bool AskBet { get; set; } = true;

    [JsonIgnore]
    private static string SettingsFileName => "settings.json";

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
