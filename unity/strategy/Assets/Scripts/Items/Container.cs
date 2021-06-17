using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{
    public Inventory _inventory;
    Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;   
    }

    public override void Interact(GameObject interactable)
    {
        var container = interactable.GetComponent<Container>();
        if (container != null)
        {
            GameManager.Instance.ToggleContainerInventory(container);
        }
    }
}
