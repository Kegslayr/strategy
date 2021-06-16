using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager: MonoBehaviour
    {
        public GameObject ModelInventoryUI;
        public GameObject ContainerInventoryUI;

        public void DebugUIHandler()
        {
            Debug.Log("DebugUIHander called...");
        }

        public void OnModelInventoryClose()
        {
            GameManager.Instance.ToggleCurrentInventory();
        }

        public void OnContainerInventoryClose()
        {
            GameManager.Instance.ToggleContainerInventory(null);
        }

        public void DisplayModelInventory(Model model)
        {
            var ui = ModelInventoryUI.GetComponent<InventoryUI>();
            ui.DisplayItems(model.Inventory);
            ModelInventoryUI.SetActive(true);
        }

        public void DisplayContainerInventory(Container container)
        {
            var ui = ContainerInventoryUI.GetComponent<InventoryUI>();
            ui.DisplayItems(container._inventory);
            ContainerInventoryUI.SetActive(true);
        }
    }
}
