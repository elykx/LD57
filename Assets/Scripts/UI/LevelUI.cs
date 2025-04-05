using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour {
    public TMP_Text levelName;
    public TMP_Text quests;

    public void SetLevel(Level level){
        if (level != null) {
            levelName.text = level.LevelName;
        }
        if (quests != null) {
            quests.text = "";
            foreach (var quest in level.Quests) {
                quests.text += "🎯 " + quest.GetQuestDescription() + "\n";
            }
        }
    }
}