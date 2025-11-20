using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drop : MonoBehaviour
{
    [Header("Loot Drop")]
    public List<Enemy_ItemBag> lootTable = new List<Enemy_ItemBag>();

    public void DropLoot()
    {
        foreach (Enemy_ItemBag lootItem in lootTable)
        {
            if (Random.Range(0f, 100f) <= lootItem.drop_chance)
            {
                InstantiateLoot(lootItem.loot_prefab);
            }
            break;
        }
    }

    void InstantiateLoot(GameObject loot)
    {
        if (loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}
