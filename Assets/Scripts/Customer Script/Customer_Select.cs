using UnityEngine;

public class Customer_Select : MonoBehaviour
{
    public Customer_Selected CSed;
    public Customer_want CW;
    public Customer_Sell CS;

    public void PickCustomer()
    {
        CSed.SetCustomer(CW);
        CS.SetSell(CW);
    }
}
