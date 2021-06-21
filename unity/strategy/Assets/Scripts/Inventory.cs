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
        public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
        public OnItemChanged OnItemChangedCallback;
        public OnEquipmentChanged OnEquipmentChangedCallback;
        public List<Item> Items = new List<Item>();
        public int Space = 20;
        public bool EquipmentManager = false;
        public SkinnedMeshRenderer EquipmentOwnerMesh;
        private int _numEquipmentSlots;
        private Equipment[] _currentEquipment;
        private SkinnedMeshRenderer[] _currentMeshes;

        private void Start()
        {
            if (EquipmentManager)
            {
                _numEquipmentSlots = Enum.GetNames(typeof(EquipmentSlot)).Length;
                _currentEquipment = new Equipment[_numEquipmentSlots];
                _currentMeshes = new SkinnedMeshRenderer[_numEquipmentSlots];
            }
        }
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
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback();
            }
            return true;
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

        public void Equip(Equipment newEquipment)
        {
            if (!EquipmentManager) return;

            int index = (int)newEquipment.Slot;
            Equipment oldEquipment = null;

            if (_currentEquipment[index] != null)
            {
                oldEquipment = _currentEquipment[index];
                Add(oldEquipment);
            }

            _currentEquipment[index] = newEquipment;
            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.Mesh);
            newMesh.transform.parent = EquipmentOwnerMesh.transform;
            newMesh.bones = EquipmentOwnerMesh.bones;
            newMesh.rootBone = EquipmentOwnerMesh.rootBone;
            _currentMeshes[index] = newMesh;
            // remove from inventory since it is equipped
            Remove(newEquipment);
            SetEquipmentBlendShapes(newEquipment, 100);
            
            if (OnEquipmentChangedCallback != null) OnEquipmentChangedCallback(newEquipment, oldEquipment);
        }

        public void UnEquip(int index)
        {
            if (!EquipmentManager) return;
            if (_currentEquipment[index] == null) return;
            Destroy(_currentMeshes[index].gameObject);
            Equipment oldEquipment = _currentEquipment[index];
            Add(oldEquipment);
            _currentEquipment[index] = null;
            SetEquipmentBlendShapes(oldEquipment, 0);

            if (OnEquipmentChangedCallback != null) OnEquipmentChangedCallback(null, oldEquipment);
        }

        public void UnEquipAll()
        {
            if (!EquipmentManager) return;
            for(int i = 0; i < _currentEquipment.Length; i++)
            {
                UnEquip(i);
            }
        }

        private void SetEquipmentBlendShapes(Equipment eq, int weight)
        {
            foreach (EquipmentBlendShape shape in eq.CoveredBlendShapes)
            {
                // Todo: Once we have the correct number of blend shapes in the mode then cast the shape to fit the region
                // EquipmentOwnerMesh.SetBlendShapeWeight((int)shape, weight);
                // for now we only have Legs
                EquipmentOwnerMesh.SetBlendShapeWeight(0, weight);
            }
        }
    }
}
