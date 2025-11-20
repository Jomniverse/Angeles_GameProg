using UnityEngine;
using System.Collections.Generic;

public class Enemy_DropCollect : MonoBehaviour
{
    [Header("Drop Table")]
    public List<Enemy_DropData> dropTable = new List<Enemy_DropData>();

    [Header("Inventory Reference")]
    public NewPlayer_Inventory playerInventory;   // Assign Player Inventory SO here

    // Called when LootBag is collected
    public void DropItemsToPlayer()
    {
        if (playerInventory == null)
        {
            Debug.LogWarning("No NewPlayer_Inventory assigned!");
            return;
        }

        foreach (var drop in dropTable)
        {
            float roll = Random.Range(0f, 100f);

            if (roll <= drop.dropChance)
            {
                NewItem_Create itemToGive = drop.itemReference;

                if (itemToGive == null)
                {
                    Debug.LogWarning("Drop table entry has NO item assigned!");
                    continue;
                }

                // Add to player inventory
                playerInventory.AddItem(itemToGive, drop.quantityAdded, true);

                Debug.Log($"Dropped: {itemToGive.item_name} x{drop.quantityAdded}");

                // SHOW NOTIFICATION
                UI_NotificationManager.Instance.ShowNotification(
                    itemToGive.item_icon,
                    itemToGive.item_name,
                    drop.quantityAdded
                );
            }
        }
    }
}