using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory_Slot : MonoBehaviour
{
    public Item_Create ITEM;

    public TMP_Text item_name;
    public Image item_sprite;
    public TMP_Text item_quantity;

    private void Start()
    {
        Item_Information();
    }

    public void Item_Information()
    {
        if (ITEM.item_isDiscovered == false)
        {
            item_name.text = "????";
            item_sprite.sprite = ITEM.item_icon;
            item_sprite.color = Color.black;   
            item_quantity.text = "";          
        }
        else
        {
            item_name.text = ITEM.item_name;
            item_sprite.sprite = ITEM.item_icon;
            item_sprite.color = Color.white;    
            item_quantity.text = ITEM.item_quantity.ToString();
        }
    }
}
