// TooltipManager.cs - менеджер тултипов, должен быть один в сцене
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI tooltipTitle;
    [SerializeField] private TextMeshProUGUI tooltipContent;

    [Header("Settings")]
    [SerializeField] private Vector2 offset = new Vector2(15, 0); // Отступ от курсора
    [SerializeField] private float showDelay = 0.3f; // Задержка появления
    [SerializeField] private TooltipPosition defaultPosition = TooltipPosition.Right;
    [SerializeField] private float maxWidth = 300f; // Максимальная ширина тултипа
    [SerializeField] private float closerOffset = 5f; // Расстояние от курсора для близкого позиционирования

    private RectTransform rectTransform;
    private Canvas parentCanvas;
    private float delayTimer;
    private bool isTimerRunning;
    private RectTransform titleRectTransform;
    private RectTransform contentRectTransform;

    // Перечисление для позиции тултипа
    public enum TooltipPosition
    {
        Right,
        Left,
        Top,
        Bottom
    }

    private void Awake()
    {
        // Синглтон
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        rectTransform = tooltipPanel.GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();

        if (tooltipTitle != null)
            titleRectTransform = tooltipTitle.GetComponent<RectTransform>();

        if (tooltipContent != null)
            contentRectTransform = tooltipContent.GetComponent<RectTransform>();

        HideTooltip();
    }

    private void Start()
    {
        // Устанавливаем ограничения ширины для контента
        if (contentRectTransform != null)
        {
            contentRectTransform.sizeDelta = new Vector2(maxWidth, contentRectTransform.sizeDelta.y);
        }

        if (titleRectTransform != null)
        {
            titleRectTransform.sizeDelta = new Vector2(maxWidth, titleRectTransform.sizeDelta.y);
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                isTimerRunning = false;
                tooltipPanel.SetActive(true);
            }
        }

        if (tooltipPanel.activeSelf)
        {
            UpdateTooltipPosition();
        }
    }

    private void UpdateTooltipPosition()
    {
        // Получаем позицию курсора
        Vector2 mousePosition = Input.mousePosition;

        // Размеры экрана и тултипа
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Обновляем размер контейнера тултипа
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        Vector2 tooltipSize = rectTransform.rect.size;

        // Определяем, с какой стороны показать тултип
        TooltipPosition position = defaultPosition;

        // Проверяем места по умолчанию (справа)
        if (position == TooltipPosition.Right && mousePosition.x + tooltipSize.x + offset.x > screenSize.x)
        {
            position = TooltipPosition.Left;
        }

        // Если слева тоже не помещается
        if (position == TooltipPosition.Left && mousePosition.x - tooltipSize.x - offset.x < 0)
        {
            position = TooltipPosition.Bottom;
        }

        // Если снизу не помещается
        if (position == TooltipPosition.Bottom && mousePosition.y - tooltipSize.y - offset.y < 0)
        {
            position = TooltipPosition.Top;
        }

        // Если сверху не помещается, оставляем справа, но корректируем по X
        if (position == TooltipPosition.Top && mousePosition.y + tooltipSize.y + offset.y > screenSize.y)
        {
            position = TooltipPosition.Right;
            // Будем корректировать после установки позиции
        }

        // Устанавливаем позицию на основе выбранного направления
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.GetComponent<RectTransform>(),
            mousePosition,
            parentCanvas.worldCamera,
            out localPoint
        );

        // Применяем позиционирование в зависимости от выбранного направления
        // Используем closerOffset для близкого позиционирования к курсору
        switch (position)
        {
            case TooltipPosition.Right:
                localPoint.x += closerOffset;
                break;
            case TooltipPosition.Left:
                localPoint.x -= tooltipSize.x + closerOffset;
                break;
            case TooltipPosition.Top:
                localPoint.y += closerOffset;
                break;
            case TooltipPosition.Bottom:
                localPoint.y -= tooltipSize.y + closerOffset;
                break;
        }

        // Устанавливаем позицию
        rectTransform.anchoredPosition = localPoint;

        // Окончательная проверка и коррекция позиции, чтобы тултип не выходил за экран
        ClampTooltipPositionToScreen();
    }

    private void ClampTooltipPositionToScreen()
    {
        Vector2 tooltipSize = rectTransform.rect.size;
        Vector2 canvasSize = parentCanvas.GetComponent<RectTransform>().rect.size;
        Vector2 position = rectTransform.anchoredPosition;

        // Проверка и коррекция по краям экрана
        if (position.x + tooltipSize.x > canvasSize.x / 2)
        {
            position.x = canvasSize.x / 2 - tooltipSize.x;
        }

        if (position.x < -canvasSize.x / 2)
        {
            position.x = -canvasSize.x / 2;
        }

        if (position.y + tooltipSize.y > canvasSize.y / 2)
        {
            position.y = canvasSize.y / 2 - tooltipSize.y;
        }

        if (position.y < -canvasSize.y / 2)
        {
            position.y = -canvasSize.y / 2;
        }

        rectTransform.anchoredPosition = position;
    }

    public void ShowTooltip(string title, string content)
    {
        // Установка текста
        tooltipTitle.gameObject.SetActive(!string.IsNullOrEmpty(title));
        tooltipTitle.text = title;
        tooltipContent.text = content;

        // Принудительно пересчитываем размеры
        if (contentRectTransform != null)
        {
            // Обновить размер текста
            contentRectTransform.sizeDelta = new Vector2(maxWidth, contentRectTransform.sizeDelta.y);
        }

        // Запуск задержки
        delayTimer = showDelay;
        isTimerRunning = true;

        // Форсируем обновление layout
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
        isTimerRunning = false;
    }
}
