using UnityEngine;

public enum NewItemCategory
{
    Weapons,
    Items,
    Materials,
    Contraptions,
    KeyItems
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/NewItem")]
public class NewItem_Create : ScriptableObject
{
    [Header("Basic Info")]
    public string item_name;
    [TextArea] public string item_description;

    [Header("Visuals")]
    public Sprite item_icon;

    [Header("Category")]
    public ItemCategory item_category;
}