using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name = "New Item";
    public Sprite Icon = null;
    public bool DefaultItem = false;
    public string Header;
    public string Description;
    public string Content;
}
