using UnityEngine;
using UnityEngine.UI;

public class Shop_ItemPlace : MonoBehaviour
{
    public Button button_place;

    public Shop_itemSlot SIS;
    public Shop_SelectedTable SST;


    private void Start()
    {
        button_place.onClick.AddListener(PlaceItem);
    }


    private void PlaceItem()
    {
        SST.SI_selected.PlaceItem(SIS.ITEM);
    }
}
