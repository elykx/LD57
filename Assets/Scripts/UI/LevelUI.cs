using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public List<QuestStickerUI> questStickers;

    public void SetLevel(Level level)
    {
        var shuffledQuests = Shuffle.ShuffleList(questStickers);
        for (int i = 0; i < level.Quests.Count; i++)
        {
            shuffledQuests[i].gameObject.SetActive(true);
            shuffledQuests[i].SetQuest(level.Quests[i].GetQuestDescription());
        }
        for (int i = level.Quests.Count; i < shuffledQuests.Count; i++)
        {
            shuffledQuests[i].gameObject.SetActive(false);
        }
    }
}