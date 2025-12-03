using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crafting_RecipeList : MonoBehaviour
{
    [Header("Recipe To Display")]
    public Item_Crafting recipe;

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

    [Header("Button")]
    public Button button_recipe;

    private void Start()
    {

        button_recipe.onClick.AddListener(DisplayRequirements);
    }

    public void DisplayRequirements()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        // MATERIAL 1
        if (recipe.required_material1.item_name == "None")
        {
            row1.SetActive(false);
        }
        else
        {
            row1.SetActive(true);
            mat1_icon.sprite = recipe.required_material1.item_icon;
            mat1_name.text = recipe.required_material1.item_name;
            mat1_have.text = recipe.required_material1.item_quantity.ToString();
            mat1_need.text = recipe.required_quantity1.ToString();
        }

        // MATERIAL 2
        if (recipe.required_material2.item_name == "None")
        {
            row2.SetActive(false);
        }
        else
        {
            row2.SetActive(true);
            mat2_icon.sprite = recipe.required_material2.item_icon;
            mat2_name.text = recipe.required_material2.item_name;
            mat2_have.text = recipe.required_material2.item_quantity.ToString();
            mat2_need.text = recipe.required_quantity2.ToString();
        }

        // MATERIAL 3
        if (recipe.required_material3.item_name == "None")
        {
            row3.SetActive(false);
        }
        else
        {
            row3.SetActive(true);
            mat3_icon.sprite = recipe.required_material3.item_icon;
            mat3_name.text = recipe.required_material3.item_name;
            mat3_have.text = recipe.required_material3.item_quantity.ToString();
            mat3_need.text = recipe.required_quantity3.ToString();
        }
    }
}
