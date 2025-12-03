using UnityEngine;
using UnityEngine.UI;

public class Inventory_DescriptionChange : MonoBehaviour
{

    public Button button_description;

    public Inventory_Description ID;
    public Inventory_Slot IS;

    private void Start()
    {
        button_description.onClick.AddListener(ChangeDescription);
    }


    private void ChangeDescription()
    {
        ID.SetDescription(IS.ITEM);
        ID.ShowDescription();
    }
}
