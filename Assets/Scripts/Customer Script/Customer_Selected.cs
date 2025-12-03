using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Selected : MonoBehaviour
{
    public Customer_want CW_selected;

    public Image want_icon;
    public TMP_Text want_name;
    public TMP_Text want_price;

    public void SetCustomer(Customer_want customer_change)
    {
        CW_selected = customer_change;

        // If customer is cleared (null), reset UI and exit
        if (CW_selected == null)
        {
            Debug.Log("Customer cleared: " + gameObject);
            return;
        }

        // If not null, update UI and log
        ShowWant();

        Debug.Log("Customer Selected: " + gameObject
                  + " Item hold: " + CW_selected.tableSlot.item_now.item_name);
    }

    public void Start()
    {
        ShowWant();
    }


    public void ShowWant()
    {
        want_name.text = CW_selected.tableSlot.item_now.item_name;
        want_icon.sprite = CW_selected.tableSlot.item_now.item_icon;
        want_price.text = "Base Price " + CW_selected.tableSlot.item_now.item_price;
    }

}
