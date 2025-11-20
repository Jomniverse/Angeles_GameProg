using UnityEngine;
using UnityEngine.UI;

public class UI_Tab : MonoBehaviour
{
    [Header("Panels")]
    public GameObject tab_menu;
    public GameObject panel_records;
    public GameObject panel_inventory;
    public GameObject panel_equipment;
    public GameObject panel_contraptions;

    [Header("Buttons")]
    public Button button_records;
    public Button button_inventory;
    public Button button_equipment;
    public Button button_contraptions;  
    public Button button_exit;


    [Header("Reference")]
    public Player_Tab PT;
    public NewUI_InventoryManager UM;

    void Start()
    {
        // Always show records first on start
        OpenRecords();

        // Hook up buttons
        ButtonInput();
    }

    private void ButtonInput()
    {
        button_exit.onClick.AddListener(ExitTab);
        button_records.onClick.AddListener(OpenRecords);
        button_inventory.onClick.AddListener(OpenInventory);
        button_equipment.onClick.AddListener(OpenEquipment);
        button_contraptions.onClick.AddListener(OpenContraptions);
    }

    private void ExitTab()
    { 
        PT.CloseTab();
    }

    public void OpenRecords()
    {
        panel_records.SetActive(true);
        panel_inventory.SetActive(false);
        panel_equipment.SetActive(false);
        panel_contraptions.SetActive(false);
    }

    private void OpenContraptions()
    {
        panel_records.SetActive(false);
        panel_inventory.SetActive(false);
        panel_contraptions.SetActive(true);
        panel_equipment.SetActive(false);
    }


    private void OpenInventory()
    {
        panel_records.SetActive(false);
        panel_inventory.SetActive(true);
        panel_equipment.SetActive(false);
        panel_contraptions.SetActive(false);

        UM.ShowAllItems();
    }

    private void OpenEquipment()
    {
        panel_records.SetActive(false);
        panel_inventory.SetActive(false);
        panel_equipment.SetActive(true);
        panel_contraptions.SetActive(false);
    }
}