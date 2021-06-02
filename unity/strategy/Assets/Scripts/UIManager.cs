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

        public void DebugUIHandler()
        {
            Debug.Log("DebugUIHander called...");
        }

        public void OnModelInventoryClose()
        {
            GameManager.Instance.ToggleCurrentInventory();
        }

        public void DisplayModelInventory(Model model)
        {
            var ui = ModelInventoryUI.GetComponent<ModelInventoryUI>();
            ui.DisplayItems(model.Inventory);
            ModelInventoryUI.SetActive(true);
        }
    }
}
