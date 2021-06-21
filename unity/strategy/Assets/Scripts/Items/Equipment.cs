using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Head, Chest, Legs, Waist, Weapon, Shield, Offhand, Feet, Neck, Finger1, Finger2, Trinket1, Trinket2 }
public enum EquipmentBlendShape { Head, Torso, Arms, Legs, Hand, Feet }
[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot Slot;
    public SkinnedMeshRenderer Mesh;
    public EquipmentBlendShape[] CoveredBlendShapes;
}
