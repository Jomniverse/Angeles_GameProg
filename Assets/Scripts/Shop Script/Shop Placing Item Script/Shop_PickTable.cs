using NUnit.Framework;
using UnityEngine;

public class Shop_PickTable : MonoBehaviour
{
    public Shop_SelectedTable SST;
    public Shop_Item SI;

    public void PickTable()
    {
        SST.SetTable(SI);
    }
}
