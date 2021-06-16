using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public Inventory _inventory;
    Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;   
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log($"Hit: {hit.collider.name}");
                var container = hit.collider.gameObject.GetComponentInParent<Container>();
                if (container != null)
                {
                    GameManager.Instance.ToggleContainerInventory(container);
                }
            }
        }
    }
}
