using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public enum InventoryType { Model, Container }

    public class InventoryUI: MonoBehaviour
    {
        public InventoryType InvType;
        public Button CloseBtn;
        public ItemSlot[] ItemSlots;

        private void Awake()
        {
            CloseBtn.onClick.AddListener(() => OnClose());
        }
        public void DisplayItems(Inventory inv)
        {
            for(int i = 0; i < ItemSlots.Count(); i++)
            {
                if (inv.Items.Count > i)
                    ItemSlots[i].AddItem(inv.Items[i]);
                else
                    ItemSlots[i].ClearItem();
            }
        }

        private void OnClose()
        {
            switch(InvType)
            {
                case InventoryType.Container:
                    GameManager.Instance.UIManager.OnContainerInventoryClose();
                    break;
                case InventoryType.Model:
                    GameManager.Instance.UIManager.OnModelInventoryClose();
                    break;
            }
        }
    }
}
