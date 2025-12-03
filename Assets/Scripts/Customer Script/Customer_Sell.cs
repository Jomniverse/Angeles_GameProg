using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customer_Sell : MonoBehaviour
{

    public GameObject leave_position;

    [Header("Current Item")]
    public Customer_want item_toSell;

    [Header("Sell")]
    public Button button_sell;

    [Header("Reference")]
    public Coin_Manager CM;
    public Customer_OpenWant COW;
    public UI_BlackScreen UB;

    private void Start()
    {
        button_sell.onClick.AddListener(SellItem);
    }

    public void SetSell(Customer_want sell_change)
    {
        item_toSell = sell_change;

        // If customer is cleared (null), reset UI and exit
        if (item_toSell == null)
        {
            Debug.Log("Customer cleared: " + gameObject);
            return;
        }

        Debug.Log("Selected recipe: " + item_toSell.tableSlot.item_now.item_name);

    }


    public void SellItem()
    {
        Leave();
        if (item_toSell == null || item_toSell.tableSlot == null || item_toSell.tableSlot.item_now == null)
        {
            Debug.LogWarning("Nothing to sell.");
            return; 
        }

        CM.coin_count += item_toSell.tableSlot.item_now.item_price;

        item_toSell.tableSlot.item_now = null;
        item_toSell.tableSlot.ItemHold();

        COW.CloseWant();

    }

    public void Leave()
    {
        StartCoroutine(LeaveRoutine());
    }

    public IEnumerator LeaveRoutine()
    {
        yield return StartCoroutine(UB.BlackScreenBegin());

  
        item_toSell.Customer.transform.SetPositionAndRotation(
            leave_position.transform.position,
            leave_position.transform.rotation
        );
        
        StartCoroutine(UB.BlackScreenEnd());


    }

}
