using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Inventory/Item Database")]
public class NewItem_Database : ScriptableObject
{
    [Header("All Item ScriptableObjects")]
    public List<Inventory_Item> allItems = new List<Inventory_Item>();

    private Dictionary<string, Inventory_Item> lookup;

    public void Initialize()
    {
        lookup = new Dictionary<string, Inventory_Item>();

        foreach (var item in allItems)
        {
            if (!lookup.ContainsKey(item.item_name))
            {
                lookup.Add(item.item_name, item);
            }
        }
    }

    public Inventory_Item GetItem(string name)
    {
        if (lookup == null)
            Initialize();

        if (lookup.TryGetValue(name, out Inventory_Item item))
            return item;

        return null;
    }
}