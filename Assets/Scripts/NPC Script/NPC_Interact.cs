using UnityEngine;
using UnityEngine.UI;

public class NPC_Interact : MonoBehaviour
{

    private bool playerInside = false;
    public UI_Interact UII;
    public UI_Crafting UIC;
    public Button close_craft;

    private void Start()
    {
        close_craft.onClick.AddListener(UIC.CloseCrafting);
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
            Debug.Log("Press E to collect loot");
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
            UIC.OpenCrafting();
        }
   
    }
}
