using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory_Description : MonoBehaviour
{
    [Header("Recipe")]
    public Item_Create description_now;

    public TMP_Text description_text;
    public TMP_Text description_name;
    public Image description_icon;
    public TMP_Text description_price;

    public void SetDescription(Item_Create description_change)
    {
        description_now = description_change;
        Debug.Log("Display recipe: " + description_now.item_name);
    }


    public void Start()
    {
        ShowDescription();
    }


    public void ShowDescription()
    {
        if (description_now.item_isDiscovered == false)
        {
            description_name.text = "????";
            description_icon.sprite = description_now.item_icon;
            description_icon.color = Color.black;
            description_text.text = "";
            description_price.text = "";
        }
        else
        {
            description_name.text = description_now.item_name;
            description_icon.sprite = description_now.item_icon;
            description_icon.color = Color.white;
            description_text.text = description_now.item_description;
            description_price.text = "Base Price " + description_now.item_price;
        }
           
    }
}
