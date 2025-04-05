using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoubleClickHandler : MonoBehaviour
{
    public float doubleClickTime = 0.3f; // Время между кликами для дабл-клика
    private float lastClickTime = 0f;
    private Button button;

    // Эти события могут быть настроены в инспекторе для выполнения нужных действий
    public UnityEngine.Events.UnityEvent onSingleClick;
    public UnityEngine.Events.UnityEvent onDoubleClick;

    void Awake()
    {
        button = GetComponent<Button>(); // Получаем компонент Button
        button.onClick.AddListener(OnButtonClick); // Подписываемся на клик
    }

    void OnButtonClick()
    {
        if (Time.time - lastClickTime <= doubleClickTime)
        {
            // Дабл-клик, вызываем событие дабл-клика
            onDoubleClick.Invoke();
        }
        else
        {
            // Одиночный клик, запоминаем время
            lastClickTime = Time.time;
            // Вызываем событие одиночного клика
            onSingleClick.Invoke();
        }
    }
}
