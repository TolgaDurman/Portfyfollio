using UnityEngine;
using UnityEngine.UI;

public class ScrollExtender : MonoBehaviour
{
    public RectTransform rectTransform { get; private set; }
    public LayoutElement layoutElement { get; private set; }
    private void Awake()
    {
        rectTransform = gameObject.AddComponent<RectTransform>();
        layoutElement = gameObject.AddComponent<LayoutElement>();
        SetSize(0,0);
    }
    public void SetSize(float width, float height)
    {
        width = Mathf.Max(0, width);
        height = Mathf.Max(0, height);
        rectTransform.sizeDelta = new Vector2(width, height);
    }
}