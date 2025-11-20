using UnityEngine;

public class Loot_ItemBag : MonoBehaviour, Loot_Interface
{
    public Enemy_DropCollect EDP;

    private void Awake()
    {
        EDP = GetComponent<Enemy_DropCollect>();
    }

    public void Collect()
    {
        if (EDP != null)
            EDP.DropItemsToPlayer();

        Destroy(gameObject);
    }
}