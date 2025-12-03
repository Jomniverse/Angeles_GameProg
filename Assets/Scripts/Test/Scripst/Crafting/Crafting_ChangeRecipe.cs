using UnityEngine;
using UnityEngine.UI;

public class Crafting_ChangeRecipe : MonoBehaviour
{
    public Crafting_Make CM;
    public Try_RecipeList TRL;

    public Item_Crafting recipe_change;

    public Button button_change;

    private void Start()
    {
        button_change.onClick.AddListener(ChangeRecipe);
    }

    private void ChangeRecipe()
    {
        CM.SetRecipe(recipe_change);
        TRL.SetRecipe(recipe_change);
        TRL.RefreshUI();
    }
}
