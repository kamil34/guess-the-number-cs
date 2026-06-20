using System;

public class Localizer
{
    private ILanguagePack _currentPack;
    private readonly Random _random = new();

    public ILanguagePack Text => _currentPack;

    public Localizer(Language language)
    {
        SetLanguage(language);
    }

    public void SetLanguage(Language language)
    {
        _currentPack = language == Language.Polish ? new PolishLanguagePack() : new EnglishLanguagePack();
    }

    public string GetRandomGuessMessage(int guess, int target)
    {
        if (guess < target)
        {
            var messages = _currentPack.LowGuessMessages;
            return messages[_random.Next(messages.Length)];
        }
        else
        {
            var messages = _currentPack.HighGuessMessages;
            return messages[_random.Next(messages.Length)];
        }
    }

    public string GetDifficultyText(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => _currentPack.Easy,
            Difficulty.Medium => _currentPack.Medium,
            Difficulty.Hard => _currentPack.Hard,
            _ => difficulty.ToString()
        };
    }
    
    public string GetLanguageName(Language language)
    {
        return language == Language.Polish ? "Polish / Polski" : "English / Angielski";
    }
}