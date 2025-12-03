using UnityEngine;

public class UI_Crafting : MonoBehaviour
{
    public GameObject panel_crafting;

    public void OpenCrafting()
    {
        panel_crafting.SetActive(true);
    }

    public void CloseCrafting()
    {
        panel_crafting.SetActive(false);
    }
}
