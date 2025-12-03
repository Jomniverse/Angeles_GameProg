using UnityEngine;

public class Shop_SelectedTable : MonoBehaviour
{
    public Shop_Item SI_selected;

    public void SetTable(Shop_Item table_change)
    {
        SI_selected = table_change;

        if (SI_selected == null)
        {
            Debug.Log("No table selected (selection cleared).");
            return;
        }

        // If a table is selected but has no item yet
        if (SI_selected.item_now == null)
        {
            Debug.Log("Table Selected: (empty slot)");
        }
        else
        {
            Debug.Log("Table Selected: " + SI_selected.item_now.item_name);
        }
    }
}
