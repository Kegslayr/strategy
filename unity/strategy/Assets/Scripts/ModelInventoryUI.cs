using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ModelInventoryUI: MonoBehaviour
    {
        public ItemSlot[] ItemSlots;

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
    }
}
