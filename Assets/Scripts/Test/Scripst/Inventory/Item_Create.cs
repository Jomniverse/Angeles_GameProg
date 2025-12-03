using UnityEngine;


public enum Item_Category
{
    Weapons,
    Materials,
    Relic,
    KeyItems
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Final Item")]

public class Item_Create : ScriptableObject
{ 
    [Header("Basic Info")]
    public string item_name;
    [TextArea] public string item_description;
    public int item_quantity;

    [Header("Visuals")]
    public Sprite item_icon;
    public bool item_isDiscovered;

    [Header("Category")]
    public Item_Category item_category;

    [Header("Pricing")]
    public int item_price;      
 
}


