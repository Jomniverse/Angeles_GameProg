using UnityEngine;
using UnityEngine.UI;

public class Shop_ItemCategory : MonoBehaviour
{
    [Header("Inventory Slots")]
    public Shop_itemSlot[] allSlots;

    [Header("Category Buttons")]
    public Button buttonAll;
    public Button buttonWeapons;
    public Button buttonMaterials;

    void Awake()
    {
        allSlots = GetComponentsInChildren<Shop_itemSlot>(true);
    }

    void Start()
    {
        if (buttonAll) buttonAll.onClick.AddListener(ShowAll);
        if (buttonWeapons) buttonWeapons.onClick.AddListener(() => ShowCategory(Item_Category.Weapons));
        if (buttonMaterials) buttonMaterials.onClick.AddListener(() => ShowCategory(Item_Category.Materials));
    }

    public void ShowAll()
    {
        foreach (var slot in allSlots)
        {
            if (slot == null || slot.ITEM == null)
            {
                slot.gameObject.SetActive(false);
                continue;
            }

            // Only show if quantity > 0
            bool hasStock = slot.ITEM.item_quantity > 0;
            slot.gameObject.SetActive(hasStock);
        }
    }

    public void ShowCategory(Item_Category category)
    {
        foreach (var slot in allSlots)
        {
            if (slot == null || slot.ITEM == null)
            {
                slot.gameObject.SetActive(false);
                continue;
            }

            // Match category AND quantity > 0
            bool match = slot.ITEM.item_category == category && slot.ITEM.item_quantity > 0;
            slot.gameObject.SetActive(match);
        }
    }
}

