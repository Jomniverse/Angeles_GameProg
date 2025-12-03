using UnityEngine;
using UnityEngine.UI;


public class Inventory_Manager : MonoBehaviour
{
    [Header("Auto Collected Slots")]
    public Inventory_Slot[] allSlots;

    void Awake()
    {
        allSlots = GetComponentsInChildren<Inventory_Slot>(true);
    }

    public void RefreshInventory()
    {
        foreach (var slot in allSlots)
        {
            if (slot != null)
                slot.Item_Information();
        }
    }
}