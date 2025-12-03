using UnityEngine;
using UnityEngine.UI;

public class Shop_TableInteract : MonoBehaviour
{
    private bool playerInside = false;
    public UI_Interact UII;
    public Shop_OpenItemList SOIL;
    public Button close_itemList;
    public Shop_PickTable SPT;
    public Shop_Interact SI;

    private void Start()
    {
        close_itemList.onClick.AddListener(SOIL.CloseItemList);
    }

    private void Update()
    {
        InteractInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SI.shop_start)
        {
            playerInside = true;
            UII.EnterInteract();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SI.shop_start)
        {
            playerInside = false;
            UII.ExitInteract();
        }
    }

    void InteractInput()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && !SI.shop_start)
        {
            SOIL.OpenItemList();
            SPT.PickTable();
        }
    }
}
