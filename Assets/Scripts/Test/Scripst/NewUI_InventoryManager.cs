using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUI_InventoryManager : MonoBehaviour
{
    [Header("References")]
    public NewPlayer_Inventory playerInventory;
    public GameObject itemDisplayPrefab;
    public Transform contentParent;
    public ScrollRect scrollRect;

    [Header("Category Buttons")]
    public Button buttonAll;
    public Button buttonWeapons;
    public Button buttonItems;
    public Button buttonMaterials;
    public Button buttonContraptions;
    public Button buttonKeyItems;

    private List<GameObject> currentItems = new List<GameObject>();

    void Start()
    {
        if (buttonAll) buttonAll.onClick.AddListener(() => ShowAllItems());
        if (buttonWeapons) buttonWeapons.onClick.AddListener(() => ShowItemsByCategory(ItemCategory.Weapons));
        if (buttonMaterials) buttonMaterials.onClick.AddListener(() => ShowItemsByCategory(ItemCategory.Materials));
        if (buttonContraptions) buttonContraptions.onClick.AddListener(() => ShowItemsByCategory(ItemCategory.Contraptions));
        if (buttonItems) buttonItems.onClick.AddListener(() => ShowItemsByCategory(ItemCategory.Items));
        if (buttonKeyItems) buttonKeyItems.onClick.AddListener(() => ShowItemsByCategory(ItemCategory.KeyItems));

        ShowAllItems(); // optional
    }

    void ClearItems()
    {
        foreach (GameObject obj in currentItems)
            Destroy(obj);

        currentItems.Clear();
    }

    public void ShowAllItems()
    {
        ClearItems();

        foreach (var slot in playerInventory.slots)
        {
            CreateItemDisplay(slot);
        }

        if (scrollRect != null)
            scrollRect.verticalNormalizedPosition = 1f;
    }

    public void ShowItemsByCategory(ItemCategory category)
    {
        ClearItems();

        foreach (var slot in playerInventory.slots)
        {
            if (slot.item != null && slot.item.item_category == category)
            {
                CreateItemDisplay(slot);
            }
        }

        if (scrollRect != null)
            scrollRect.verticalNormalizedPosition = 1f;
    }

    void CreateItemDisplay(InventorySlot slot)
    {
        GameObject newItem = Instantiate(itemDisplayPrefab, contentParent);
        NewUI_DisplayInventory display = newItem.GetComponent<NewUI_DisplayInventory>();
        display.SetItemInfo(slot);
        currentItems.Add(newItem);
    }
}