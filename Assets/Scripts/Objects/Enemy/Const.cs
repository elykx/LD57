using System.Collections.Generic;

public static class EnemiesConst
{
    public static Malware MalwareEnemy1 = new Malware("Malware 1", 1, 8);
    public static Malware MalwareEnemy2 = new Malware("Malware 2", 1, 8);
    public static List<Enemy> FirsLevelEnemies = new() { MalwareEnemy1, MalwareEnemy2 };
}