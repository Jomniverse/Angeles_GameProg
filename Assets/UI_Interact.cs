using UnityEngine;

public class UI_Interact : MonoBehaviour
{
    public Transform interactionHandler;
    public GameObject pressE;

    GameObject interactE;

    public void EnterInteract()
    {
        interactE = Instantiate(pressE, interactionHandler);
    }

    public void ExitInteract()
    {
        Destroy(interactE);
    }
}
