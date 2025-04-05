using UnityEngine;

public class UI : MonoBehaviour
{
    public LevelUI levelUI;
    private void Awake()
    {
        G.ui = this;
    }

    public void SetLevelUI(Level level)
    {
        levelUI.SetLevel(level);
    }

}