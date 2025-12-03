using UnityEngine;

public class Shop_OpenItemList : MonoBehaviour
{
    public GameObject panel_ItemList;
    public Shop_ItemCategory SIC;
    public void OpenItemList()
    {
        panel_ItemList.SetActive(true);
        SIC.ShowAll();
    }

    public void CloseItemList()
    {
        panel_ItemList.SetActive(false);
    }
}
