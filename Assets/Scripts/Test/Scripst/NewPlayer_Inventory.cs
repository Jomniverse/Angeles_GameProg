using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    // Drag your NewItem_Create ScriptableObject here in the inspector
    public NewItem_Create item;

    // How many of this item the player has
    public int quantity;

    // Whether this item is already discovered for this player
    public bool isDiscovered;
}

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Inventory/Player Inventory")]
public class NewPlayer_Inventory : ScriptableObject
{
    // You can edit this list directly in the inspector
    public List<InventorySlot> slots = new List<InventorySlot>();

    // Optional helper if you still want to add items via code
    public void AddItem(NewItem_Create item, int amount, bool discoveredOnPickup = true)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.quantity += amount;

                // Optionally mark as discovered once obtained
                if (discoveredOnPickup)
                    slot.isDiscovered = true;

                return;
            }
        }

        // If not found, create new slot
        slots.Add(new InventorySlot
        {
            item = item,
            quantity = amount,
            isDiscovered = discoveredOnPickup
        });
    }

    public bool HasDiscovered(NewItem_Create item)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
                return slot.isDiscovered;
        }

        return false;
    }
}