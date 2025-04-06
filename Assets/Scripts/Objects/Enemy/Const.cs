using System.Collections.Generic;

public static class EnemiesConst
{
    public static Malware MalwareEnemy1 = new Malware("Malware 1", 1, 8,
    "> !! anomaly detected !!\n" +
    "> unauthorized process started: malware.exe\n" +
    "> injecting code into stack...\n" +
    "> process is running\n", null);
    public static Malware MalwareEnemy2 = new Malware("Malware 2", 1, 8,
    "> !! anomaly detected !!\n" +
    "> unauthorized process started: malware.exe\n" +
    "> injecting code into stack...\n" +
    "> process is running\n", null);
    public static List<Enemy> FirsLevelEnemies = new() { MalwareEnemy1, MalwareEnemy2 };
    public static List<Enemy> SecondLevelEnemies = new() { MalwareEnemy1, MalwareEnemy2 };
}