using UnityEngine;

[System.Serializable]
public class Loot_DropData
{
    [Header("Drop Info")]
    public Item_Create itemReference;
    [Range(0f, 100f)] public float dropChance = 50f;
    public int quantityAdded = 1;
}
