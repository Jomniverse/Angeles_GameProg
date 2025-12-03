using UnityEngine;
using System.Collections;

public class Customer_SpawnPoint : MonoBehaviour
{

    [Header("Customer Spawn Points")]
    public GameObject[] customer_position;   

    [Header("Existing Customers")]
    public GameObject[] customers;

    public UI_BlackScreen UB;

    public void SpawnCustomers()
    {
        StartCoroutine(SpawnCustomersRoutine());
    }


    public IEnumerator SpawnCustomersRoutine()
    {
        yield return StartCoroutine(UB.BlackScreenBegin());


        for (int i = 0; i < customer_position.Length; i++)
        {
    
            customers[i].transform.SetPositionAndRotation(
                customer_position[i].transform.position,
                customer_position[i].transform.rotation
            );
    
        }
        StartCoroutine(UB.BlackScreenEnd());
    }
}
