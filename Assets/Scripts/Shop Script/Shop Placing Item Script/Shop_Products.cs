using UnityEngine;
using UnityEngine.UI;

public class Shop_Products : MonoBehaviour
{
    [Header("Product Placed Slots")]
    public Shop_Item[] product_slot;


    public Item_Create[] GetAllChosenItems()
    {
        // Create an array with the same size as shopSlots
        Item_Create[] chosenItems = new Item_Create[product_slot.Length];

        for (int i = 0; i < product_slot.Length; i++)
        {
            if (product_slot[i] != null)
            {
                chosenItems[i] = product_slot[i].item_now;

                if (chosenItems[i] != null)
                {
                    Debug.Log("Slot " + i + " has: " + chosenItems[i].item_name);
                }
                else
                {
                    Debug.Log("Slot " + i + " is empty.");
                }
            }
        }

        return chosenItems;
    }

    
}
