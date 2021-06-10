using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Header;
    public string Description;
    [Multiline()]
    public string Content;
    private static LTDescr _delay;

    private void OnMouseEnter()
    {
        ShowTooltip();
    }

    private void OnMouseExit()
    {
        HideTooltip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }

    private void ShowTooltip()
    {
        _delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(Header, Description, Content);
        });
    }

    private void HideTooltip()
    {
        LeanTween.cancel(_delay.uniqueId);
        TooltipSystem.Hide();
    }
}
