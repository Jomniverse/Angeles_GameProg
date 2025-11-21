using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Crafting")]
public class Item_Crafting : ScriptableObject
{
    [Header("Item To Craft")]
    public Item_Create craft_item;

    [Header("Material1")]
    public Item_Create required_material1;
    public int required_quantity1;

    [Header("Material2")]
    public Item_Create required_material2;
    public int required_quantity2;

    [Header("Required Materials")]
    public MaterialRequirement[] craft_materials;
}

[System.Serializable]
public class MaterialRequirement
{
    public Item_Create required_materials; 
    public int required_quantity;   
}
