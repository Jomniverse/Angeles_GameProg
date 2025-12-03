using UnityEngine;
using UnityEngine.UI;

public class Shop_Interact : MonoBehaviour
{
    private bool playerInside = false;
    public UI_Interact UII;
    public Customer_SpawnPoint CSP;
    public bool shop_start = false;

    private void Update()
    {
        InteractInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !shop_start)
        {
            playerInside = true;
            Debug.Log("Press E to start shop");
            UII.EnterInteract();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !shop_start)
        {
            playerInside = false;
            UII.ExitInteract();
        }
    }

    void InteractInput()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && !shop_start)
        {
            CSP.SpawnCustomers();
            UII.ExitInteract();
            shop_start = true;
            Debug.Log("shop");
        }

    }
}
