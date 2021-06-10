using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipDialog : MonoBehaviour
{
    public TextMeshProUGUI HeaderField;
    public TextMeshProUGUI DescriptionField;
    public TextMeshProUGUI ContentField;
    public LayoutElement LayoutElement;
    public int WrapLimit;
    public RectTransform Rect;

    public void SetTooltip(string header, string description, string content)
    {
        HeaderField.text = header;
        DescriptionField.text = description;
        ContentField.text = content;

        int headerLength = HeaderField.text.Length;
        int descriptionLength = DescriptionField.text.Length;
        int contentLength = ContentField.text.Length;

        LayoutElement.enabled = (headerLength > WrapLimit || descriptionLength > WrapLimit || contentLength > WrapLimit) ? true : false;
    }

    private void Awake()
    {
        Rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 pos = Input.mousePosition;
        float pivotX = pos.x / Screen.width;
        float pivotY = pos.y / Screen.height;
        Rect.pivot = new Vector2(pivotX, pivotY);
        transform.position = pos;
    }
}
