using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Head, Chest, Legs, Waist, Weapon, Shield, Offhand, Feet, Neck, Finger1, Finger2, Trinket1, Trinket2 }
[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot Slot;
}
