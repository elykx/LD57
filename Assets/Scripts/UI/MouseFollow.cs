using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float maxOffset = 10f;
    public float followSpeed = 5.0f;

    private RectTransform rectTransform;
    private Vector2 initialAnchoredPosition;
    private Canvas parentCanvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialAnchoredPosition = rectTransform.anchoredPosition;

        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
        {
            Debug.LogError("UI элемент должен находиться внутри Canvas");
        }
    }

    void Update()
    {
        if (parentCanvas == null) return;

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.GetComponent<RectTransform>(),
            Input.mousePosition,
            parentCanvas.worldCamera,
            out localMousePosition);

        Vector2 objectPositionOnCanvas;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.GetComponent<RectTransform>(),
            RectTransformUtility.WorldToScreenPoint(parentCanvas.worldCamera, transform.position),
            parentCanvas.worldCamera,
            out objectPositionOnCanvas);

        Vector2 direction = localMousePosition - objectPositionOnCanvas;

        Vector2 clampedDirection = Vector2.ClampMagnitude(direction, maxOffset);

        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition,
            initialAnchoredPosition + clampedDirection,
            Time.deltaTime * followSpeed
        );
    }
}
