using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour {
    public TMP_Text levelName;

    public void SetLevel(Level level){
        if (level != null) {
            levelName.text = level.LevelName;
        }
    }
}