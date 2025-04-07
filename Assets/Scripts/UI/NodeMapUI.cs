using UnityEngine;
using UnityEngine.UI;

public class NodeMapUI : MonoBehaviour
{
    public int index;
    public Image line;
    public Sprite disabledLine;
    public Sprite activeLine;
    public Button button;

    void Update()
    {
        if (SessionData.Instance.currentLevel <= index)
        {
            line.sprite = disabledLine;
        }
        else
        {
            line.sprite = activeLine;
        }
    }

}