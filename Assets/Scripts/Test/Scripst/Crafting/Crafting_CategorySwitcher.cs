using UnityEngine;
using UnityEngine.UI;

public class Crafting_CategorySwitcher : MonoBehaviour
{
    [Header("Inventory Slots")]
    public Crafting_Slot[] allSlots;

    [Header("Category Buttons")]
    public Button buttonAll;
    public Button buttonWeapons;
    public Button buttonMaterials;

    void Start()
    {
        if (buttonAll) buttonAll.onClick.AddListener(() => ShowAll());
        if (buttonWeapons) buttonWeapons.onClick.AddListener(() => ShowCategory(Item_Category.Weapons));
        if (buttonMaterials) buttonMaterials.onClick.AddListener(() => ShowCategory(Item_Category.Materials));
    }

    void Awake()
    {
        allSlots = GetComponentsInChildren<Crafting_Slot>(true);
    }

    public void ShowAll()
    {
        foreach (var slot in allSlots)
            slot.gameObject.SetActive(true);
    }

    public void ShowCategory(Item_Category category)
    {
        foreach (var slot in allSlots)
        {
            if (slot == null)
                continue;

            if (slot.recipe == null)
            {
                slot.gameObject.SetActive(false);
                continue;
            }

            bool match = slot.recipe.item_category == category;
            slot.gameObject.SetActive(match);
        }
    }
}