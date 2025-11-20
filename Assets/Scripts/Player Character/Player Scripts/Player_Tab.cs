using Unity.VisualScripting;
using UnityEngine;

public class Player_Tab : MonoBehaviour
{
    [Header("State")]
    private bool isTabMenuOpen = false;

    [Header("Panels")]
    public GameObject tab_menu;

    [Header("References")]
    public UI_Tab UT; 

    

    void Start()
    {
        
        // Ensure the tab menu is hidden at the start
        tab_menu.SetActive(false);
    }

    private void Update()
    {
        TabInput();
    }


    private void TabInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle menu visibility
            isTabMenuOpen = !isTabMenuOpen;

            tab_menu.SetActive(isTabMenuOpen);

            if (isTabMenuOpen)
            {
                // Make sure Records panel is always first when opening
                UT.OpenRecords();
            }
        }
    }

    // Called from UI_Tab when Exit button is pressed
    public void CloseTab()
    {
        isTabMenuOpen = false;
        tab_menu.SetActive(false);
    }
}