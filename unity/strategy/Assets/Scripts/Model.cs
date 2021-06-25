using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Model: MonoBehaviour
    {
        public int Id;
        public Inventory Inventory;

        private void Start()
        {
            Inventory = GetComponent<Inventory>();
        }

        public void Save()
        {
            SaveManager.SaveModel(this);
        }

        public void Load()
        {
            var data = SaveManager.LoadModel();
            Id = data.Owner;

            // load items

            // load equipment
            for(int i = 0; i < Inventory.NumEquipmentSlots; i++)
            {
                // 0 means null or nothing equipped
                if (data.Equipment[i] != 0)
                {
                    var equipment = LootManager.Instance.GetEquipmentById(data.Equipment[i]);
                    GameManager.Instance.OnEquipItem(equipment);
                }
            }
        }
    }
}
