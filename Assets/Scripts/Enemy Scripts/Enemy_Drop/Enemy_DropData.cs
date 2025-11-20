using UnityEngine;

[System.Serializable]
public class Enemy_DropData 
{
    [Header("Drop Info")]
    public NewItem_Create itemReference;
    [Range(0f, 100f)] public float dropChance = 50f;
    public int quantityAdded = 1;
   
}
