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

    private void Start()
    {
        Button.onClick.AddListener(() => OnUseItem());
    }

    public void AddItem(Item item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Icon.enabled = true;
        Button.interactable = true;
    }

    public void ClearItem()
    {
        Item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        Button.interactable = false;
    }

    public void UseItem()
    {
        GameManager.Instance.OnUseInventoryItem(Item);
    }

    private void OnUseItem()
    {
        GameManager.Instance.OnUseInventoryItem(Item);
    }
}
