using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoubleClickHandler : MonoBehaviour
{
    public float doubleClickTime = 0.3f;
    private float lastClickTime = 0f;
    private Button button;

    public UnityEngine.Events.UnityEvent onSingleClick;
    public UnityEngine.Events.UnityEvent onDoubleClick;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (Time.time - lastClickTime <= doubleClickTime)
        {
            onDoubleClick.Invoke();
        }
        else
        {
            lastClickTime = Time.time;
            onSingleClick.Invoke();
        }
    }
}
