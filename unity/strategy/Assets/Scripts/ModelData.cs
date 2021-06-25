using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [System.Serializable]
    public class ModelData
    {
        public int Owner;
        public int[] Items;
        public int[] Equipment;

        public ModelData(Model model)
        {
            Owner = model.Id;
            Items = new int[model.Inventory.ItemCount];
            Equipment = new int[model.Inventory.Equipment.Length];
            for(int i = 0; i < model.Inventory.ItemCount; i++)
            {
                Items[i] = model.Inventory.Items[i].Id;
            }
            for(int i = 0; i < model.Inventory.Equipment.Length; i++)
            {
                if (model.Inventory.Equipment[i] != null)
                    Equipment[i] = model.Inventory.Equipment[i].Id;
            }
        }
    }
}
