using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item Item;
    public override void Interact(GameObject interactable)
    {
        Pickup();
    }

    void Pickup()
    {
        Debug.Log($"Picking up item {Item.Name}");
        if (GameManager.Instance.Current.Inventory.Add(Item))
            Destroy(gameObject);
    }
}
