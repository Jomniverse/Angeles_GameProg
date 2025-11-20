using UnityEngine;
using System.Collections.Generic;

// Categories to separate items
public enum ItemCategory
{
    Weapons,
    Items,
    Materials,
    Contraptions,
    KeyItems
}

[System.Serializable]
public class Inventory_Item
{
    [Header("Basic Info")]
    public string item_name;
    [TextArea] public string item_description;

    [Header("Visuals")]
    public Sprite item_icon;

    [Header("Stats")]
    public int item_quantity = 1;
    public bool item_discovered = false;

    [Header("Category")]
    public ItemCategory item_category;
}

// ScriptableObject holding multiple items
[CreateAssetMenu(fileName = "New Item List", menuName = "Inventory/Item List")]
public class Inventory_ItemList : ScriptableObject
{
    [Header("All Items in this List")]
    public List<Inventory_Item> items = new List<Inventory_Item>();
}