using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting_Slot : MonoBehaviour
{
    public Item_Create recipe;

    [Header("References")]
    public TMP_Text item_name;
    public Image item_sprite;
    public TMP_Text item_quantity;


    private void Start()
    {
        item_name.text = recipe.item_name;
        item_sprite.sprite = recipe.item_icon;
    }
    private void Update()
    {
        item_quantity.text = recipe.item_quantity.ToString();

    }
}