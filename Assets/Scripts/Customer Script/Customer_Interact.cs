using UnityEngine;
using UnityEngine.UI;

public class Customer_Interact : MonoBehaviour
{
    private bool playerInside = false;
    public UI_Interact UII;
    public Customer_OpenWant COW;
    public Customer_Select CS;
    public Button close_wantpanel;

    private void Start()
    {
        close_wantpanel.onClick.AddListener(COW.CloseWant);
    }


    private void Update()
    {
        InteractInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
            UII.EnterInteract();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            UII.ExitInteract();
        }
    }

    void InteractInput()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            COW.OpenWant();
            CS.PickCustomer();
        }
    }
}
