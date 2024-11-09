using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class EnhancedScrollView : MonoBehaviour
{
    private RectTransform content;
    private ContentSizeFitter contentSizeFitter;
    private VerticalLayoutGroup layoutGroup;
    private ScrollRect scrollView;

    private ScrollExtender dummyObject;
    private RectTransform prototype;
    private int displayCount = 0;
    private List<GameObject> displayNodes = new List<GameObject>();

    private void Awake()
    {
        scrollView = GetComponent<ScrollRect>();
        content = scrollView.content;
        prototype = content.GetChild(0).GetComponent<RectTransform>();
        displayNodes.Add(prototype.gameObject);
        var dummy = new GameObject("Dummy", typeof(ScrollExtender));
        dummy.transform.SetParent(content);
        dummy.transform.SetAsFirstSibling();
        dummyObject = dummy.GetComponent<ScrollExtender>();
        contentSizeFitter = content.GetComponent<ContentSizeFitter>();
        layoutGroup = content.GetComponent<VerticalLayoutGroup>();
        scrollView.onValueChanged.AddListener(OnDeltaChange);
        CalculateVisibleNodes();
        GenerateDisplayNodes();
    }

    private void CalculateVisibleNodes()
    {
        displayCount = 0;
        float nodeTotalHeight = prototype.rect.height + layoutGroup.spacing;
        Debug.Log("Node Total Height: " + nodeTotalHeight);
        float visibleHeight = scrollView.transform.GetComponent<RectTransform>().rect.height;
        Debug.Log("Visible Height: " + visibleHeight);
        displayCount = Mathf.CeilToInt(visibleHeight / nodeTotalHeight) + 1;
        Debug.Log("Display Count: " + displayCount);
    }
    private void GenerateDisplayNodes()
    {
        for (int i = displayNodes.Count; i < displayCount; i++)
        {
            var newNode = Instantiate(prototype.gameObject, content);
            displayNodes.Add(newNode);
        }
    }

    private void OnDeltaChange(Vector2 delta)
    {
        Debug.Log("Delta: " + delta);
        
    }
}