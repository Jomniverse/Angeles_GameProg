using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewUI_DisplayInventory : MonoBehaviour
{
    [Header("UI References")]
    public Image itemIcon;
    public TMP_Text itemNameText;
    public TMP_Text itemQuantityText;

    public void SetItemInfo(InventorySlot slot)
    {
        // Set icon
        itemIcon.sprite = slot.item.item_icon;

        if (slot.isDiscovered)
        {
            itemNameText.text = slot.item.item_name;
            itemQuantityText.text = "x" + Mathf.Clamp(slot.quantity, 0, 99);
            itemIcon.color = Color.white;
        }
        else
        {
            itemNameText.text = "????";
            itemQuantityText.text = "";
            itemIcon.color = Color.black;
        }
    }
}