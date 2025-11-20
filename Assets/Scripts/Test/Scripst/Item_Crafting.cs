using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item_Crafting")]
public class Item_Crafting : ScriptableObject
{
    [Header("Item To Craft")]
    public NewItem_Create craftedItem;   // The final crafted output

    [Header("Required Materials")]
    public MaterialRequirement[] materials;   // Array of required materials
}

[System.Serializable]
public class MaterialRequirement
{
    public NewItem_Create materialItem;   // The material needed
    public int quantityRequired;      // How many units needed
}
