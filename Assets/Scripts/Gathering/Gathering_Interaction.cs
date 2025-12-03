using UnityEngine;

public class Gathering_Interaction : MonoBehaviour
{
    public Loot_DropTable LDT;
    [SerializeField] private int max_tries;
    [SerializeField] private int tries;
    private bool playerInside = false;

    public UI_Announcement UA;
    public UI_Interact UII;

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
        if (playerInside && Input.GetKeyDown(KeyCode.E) && max_tries != tries)
        {
            LDT.DropItemsToPlayer();
            tries++;
        }
        else if (playerInside && Input.GetKeyDown(KeyCode.E) && max_tries == tries)
        {
            UA.ShowAnnouncement();
        }
    }
}
