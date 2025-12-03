using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Try_RecipeList : MonoBehaviour
{
    [Header("Recipe")]
    public Item_Crafting recipe_now;


    [Header("Required Material 1 UI")]
    public GameObject row1;
    public Image mat1_icon;
    public TMP_Text mat1_name;
    public TMP_Text mat1_have;
    public TMP_Text mat1_need;

    [Header("Required Material 2 UI")]
    public GameObject row2;
    public Image mat2_icon;
    public TMP_Text mat2_name;
    public TMP_Text mat2_have;
    public TMP_Text mat2_need;

    [Header("Required Material 3 UI")]
    public GameObject row3;
    public Image mat3_icon;
    public TMP_Text mat3_name;
    public TMP_Text mat3_have;
    public TMP_Text mat3_need;

    public void SetRecipe(Item_Crafting recipe_change)
    {
        recipe_now = recipe_change;
        Debug.Log("Display recipe: " + recipe_now.craft_item.item_name);
    }


    public void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        var recipe_item = recipe_now;

        // MATERIAL 1
        if (recipe_item.required_material1.item_name == "None")
        {
            row1.SetActive(false);
        }
        else
        {
            row1.SetActive(true);
            mat1_icon.sprite = recipe_item.required_material1.item_icon;
            mat1_name.text = recipe_item.required_material1.item_name;
            mat1_have.text = recipe_item.required_material1.item_quantity.ToString();
            mat1_need.text = recipe_item.required_quantity1.ToString();
        }

        // MATERIAL 2
        if (recipe_item.required_material2.item_name == "None")
        {
            row2.SetActive(false);
        }
        else
        {
            row2.SetActive(true);
            mat2_icon.sprite = recipe_item.required_material2.item_icon;
            mat2_name.text = recipe_item.required_material2.item_name;
            mat2_have.text = recipe_item.required_material2.item_quantity.ToString();
            mat2_need.text = recipe_item.required_quantity2.ToString();
        }

        // MATERIAL 3
        if (recipe_item.required_material3.item_name == "None")
        {
            row3.SetActive(false);
        }
        else
        {
            row3.SetActive(true);
            mat3_icon.sprite = recipe_item.required_material3.item_icon;
            mat3_name.text = recipe_item.required_material3.item_name;
            mat3_have.text = recipe_item.required_material3.item_quantity.ToString();
            mat3_need.text = recipe_item.required_quantity3.ToString();
        }
    }
}
