using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory: MonoBehaviour
    {
        public delegate void OnItemChanged();
        public OnItemChanged OnItemChagedCallback;
        public List<Item> Items = new List<Item>();
        public int Space = 20;

        public bool Add(Item item)
        {
            if (Items.Count >= Space)
            {
                Debug.Log("Inventory is full");
                return false;
            }
            if (!item.DefaultItem)
            {
                Items.Add(item);
                if (OnItemChagedCallback != null)
                    OnItemChagedCallback();
            }
            return true;
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }
    }
}
