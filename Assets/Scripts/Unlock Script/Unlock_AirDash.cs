using UnityEngine;

public class Unlock_AirDash : MonoBehaviour
{
    public bool playerInside = false;
    public bool isUnlock = false;

    [SerializeField] private Player_Unlockable PU;

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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;

        }
    }
    void InteractInput()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && !isUnlock)
        {
            PU.unlockAirDash = true;
            isUnlock = true;
        }
    }
}
