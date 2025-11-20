using UnityEngine;

public class Player_Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Loot_Interface loot = collision.GetComponent<Loot_Interface>();
        if(loot != null)
        {
            loot.Collect();
        }
    }
}
