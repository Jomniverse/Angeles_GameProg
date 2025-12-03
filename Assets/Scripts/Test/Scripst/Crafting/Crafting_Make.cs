using UnityEngine;
using UnityEngine.UI;

public class Crafting_Make : MonoBehaviour
{
    [Header("Current Recipe")]
    public Item_Crafting recipe_now;

    [Header("Button")]
    public Button button_crafting;

    [Header("Reference")]
    public Try_RecipeList TRL;
        
    private void Start()
    {
        button_crafting.onClick.AddListener(CraftItem);
    }

    public void SetRecipe(Item_Crafting recipe_change)
    {
        recipe_now = recipe_change;
        Debug.Log("Selected recipe: " + recipe_now.craft_item.item_name);
    }

   


    public void CraftItem()
    {
        var recipe_item = recipe_now;

        bool requirement1 = recipe_item.required_material1.item_quantity >= recipe_item.required_quantity1;
        bool requirement2 = recipe_item.required_material2.item_quantity >= recipe_item.required_quantity2;
        bool requirement3 = recipe_item.required_material3.item_quantity >= recipe_item.required_quantity3;

        if (requirement1 && requirement2 && requirement3)
        {
            recipe_item.craft_item.item_quantity += 1;

            recipe_item.required_material1.item_quantity -= recipe_item.required_quantity1;
            recipe_item.required_material2.item_quantity -= recipe_item.required_quantity2;
            recipe_item.required_material3.item_quantity -= recipe_item.required_quantity3;

            TRL.RefreshUI();

            Debug.Log("Craft Item");
        }
        else
        {
            Debug.Log("Not enough");
        }
    }
}
