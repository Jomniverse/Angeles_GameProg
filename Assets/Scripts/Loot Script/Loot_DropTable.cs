using System.Collections.Generic;
using UnityEngine;

public class Loot_DropTable : MonoBehaviour
{
    [Header("Drop Table")]
    public List<Loot_DropData> dropTable = new List<Loot_DropData>();

    public void DropItemsToPlayer()
    {
        foreach (var drop in dropTable)
        {
            float roll = Random.Range(0f, 100f);

            if (roll <= drop.dropChance)
            {
                Item_Create itemToGive = drop.itemReference;

                if (itemToGive != null)
                {
                    // Add quantity to the ScriptableObject
                    itemToGive.item_quantity += drop.quantityAdded;

                    itemToGive.item_isDiscovered = true;

                    // **Show Notification**
                    UI_NotificationManager.Instance.ShowNotification(
                        itemToGive.item_icon,
                        itemToGive.item_name,
                        drop.quantityAdded
                    );

                    Debug.Log($"Loot Added: {drop.quantityAdded}x {itemToGive.item_name}");
                }
            }
        }
    }
}
