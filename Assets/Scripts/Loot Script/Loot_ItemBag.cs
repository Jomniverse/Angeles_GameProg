using UnityEngine;

public class Loot_ItemBag : MonoBehaviour, Loot_Interface
{
    public Loot_DropTable LDT;

    private void Awake()
    {
        LDT = GetComponent<Loot_DropTable>();
    }

    public void Collect()
    {
        if (LDT != null)
            LDT.DropItemsToPlayer();

        Destroy(gameObject);
    }
}