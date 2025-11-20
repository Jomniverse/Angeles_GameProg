using UnityEngine;

[System.Serializable]
public class Enemy_ItemBag
{
    [Header("Loot Drop Rate")]
    public GameObject loot_prefab;
    [Range(0, 100)] public float drop_chance;
}
