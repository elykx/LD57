using System.Linq;

public interface ILevelQuest
{
    string GetQuestDescription();
    bool IsCompleted(Level level);
}

public class EliminateAllEnemiesQuest : ILevelQuest
{
    public string GetQuestDescription() => "Уничтожьте всех врагов";

    public bool IsCompleted(Level level)
    {
        return level.Enemies.Count() == 0;
    }
}
