// Game interface - contract for game implementations
public interface IGame
{
    ScoreEntry? Play(Difficulty difficulty);
}
