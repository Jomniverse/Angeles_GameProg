using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting_Slot : MonoBehaviour
{
    public Item_Crafting item;

    public TMP_Text item_name;
    public Image item_sprite;

    private void Start()
    {
        Craft_Information();
    }

    void Craft_Information()
    {
        item_name.text = item.craftedItem.item_name;
        item_sprite.sprite = item.craftedItem.item_icon;
    }
}
