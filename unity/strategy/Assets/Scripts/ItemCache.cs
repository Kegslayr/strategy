using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemCache: MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
        }

        public Equipment GetEquipmentById(int id)
        {
            foreach (var item in _inventory.Items)
            {
                if (item is Equipment && item.Id == id)
                {
                    return item as Equipment;
                }
            }
            return null;
        }
    }
}
