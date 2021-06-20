using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Button Button;
    public Image Icon;
    Item Item;
    private TooltipTrigger _tooltip;

    private void Start()
    {
        Button.onClick.AddListener(() => OnUseItem());
    }

    public void AddItem(Item item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Icon.enabled = true;
        if (_tooltip == null) _tooltip = Icon.GetComponent<TooltipTrigger>();
        _tooltip.Item = item;
        Button.interactable = true;
    }

    public void ClearItem()
    {
        Item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        Button.interactable = false;
    }

    private void OnUseItem()
    {
        // Determine the item type and act accordingly
        if (Item is Equipment)
        {
            GameManager.Instance.OnEquipItem(Item as Equipment);
        } else
            GameManager.Instance.OnUseInventoryItem(Item);
    }
}
