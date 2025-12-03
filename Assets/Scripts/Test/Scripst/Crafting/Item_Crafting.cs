using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Crafting")]
public class Item_Crafting : ScriptableObject
{
    [Header("Item To Craft")]
    public Item_Create craft_item;

    [Header("Required Materials")]
    public Item_Create required_material1;
    public int required_quantity1;
    [Space(20)]

    public Item_Create required_material2;
    public int required_quantity2;
    [Space(20)]

    public Item_Create required_material3;
    public int required_quantity3;
}