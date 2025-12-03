
using UnityEngine;

public class Shop_Item : MonoBehaviour
{
    public Item_Create item_now;
    public SpriteRenderer item_icon;

    private void Start()
    {
        ItemHold();
    }

    public void PlaceItem(Item_Create item_change)
    { 
        // 1. Give back quantity to item that was here before
        if (item_now != null) 
        { 
            item_now.item_quantity++; 
        } 
        
        // 2. Set new item
        item_now = item_change; 
        
        // 3. Take 1 quantity from new item (if any)
        if (item_now != null) 
        {
            item_now.item_quantity--; 
            Debug.Log("Placed: " + item_now.item_name + " | New qty: " + item_now.item_quantity); 
        } 
        
        else 
        { 
            Debug.Log("Cleared recipe slot"); 
        } 
        
        ItemHold(); 
    }

    public void ItemHold()
    {
        if (item_now == null)
        {
            Color item_color = item_icon.color;
            item_color.a = 0f;
            item_icon.color = item_color;
            item_icon.sprite = null;
        }
        else
        {
            item_icon.sprite = item_now.item_icon;

            Color visible = item_icon.color;
            visible.a = 1f;
            item_icon.color = visible;
        }
    }

}
