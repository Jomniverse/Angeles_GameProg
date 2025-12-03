
using UnityEngine;
using UnityEngine.UI;

public class Shop_ItemRemove : MonoBehaviour
{
    public Button button_remove;

    public Shop_SelectedTable SST;
    

    private void Start()
    {
        button_remove.onClick.AddListener(RemoveItem);
    }


    private void RemoveItem()
    {
        SST.SI_selected.PlaceItem(null);
    }
}
