using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting_Slot : MonoBehaviour
{
    public Item_Crafting recipe; // assign in inspector

    public TMP_Text item_name;
    public Image item_sprite;

    private void Start()
    {
        item_name.text = recipe.craft_item.item_name;
        item_sprite.sprite = recipe.craft_item.item_icon;

    }
}