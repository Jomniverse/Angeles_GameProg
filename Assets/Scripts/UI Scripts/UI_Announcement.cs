using UnityEngine;

public class UI_Announcement : MonoBehaviour
{
    public Transform playerUI;
    public GameObject limitprefab;

    public float lifetime = 1f;

    public void ShowAnnouncement()
    {
        GameObject notifObj = Instantiate(limitprefab, playerUI);


        Destroy(notifObj, lifetime);
    }
}
