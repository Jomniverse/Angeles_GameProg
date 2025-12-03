using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop_itemSlot : MonoBehaviour
{
    public Item_Create ITEM;

    public TMP_Text item_name;
    public Image item_sprite;
    public TMP_Text item_quantity;


    private int lastQuantity = -1;


    private void Start()
    {
        ShopItem_information();
        RefreshQuantity();
    }

    private void Update()
    {
        RefreshQuantity();
    }


    public void ShopItem_information()
    {
        item_name.text = ITEM.item_name;
        item_sprite.sprite = ITEM.item_icon;
        item_quantity.text = ITEM.item_quantity.ToString();

        ShopItem_reveal();
    }

    public void ShopItem_reveal()
    {
        if (ITEM.item_quantity == 0)
        {
           gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);         
        }
    }

    private void RefreshQuantity()
    {
        if (ITEM == null)
        {
            gameObject.SetActive(false);
            return;
        }

        // If quantity did not change, do nothing
        if (ITEM.item_quantity == lastQuantity)
            return;

        lastQuantity = ITEM.item_quantity;

        // Update text
        item_quantity.text = lastQuantity.ToString();

        // Show only if quantity > 0
        gameObject.SetActive(lastQuantity > 0);
    }
}
