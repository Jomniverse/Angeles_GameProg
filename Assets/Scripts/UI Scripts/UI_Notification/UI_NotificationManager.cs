using UnityEngine;
using UnityEngine.Playables;

public class UI_NotificationManager : MonoBehaviour
{
    public static UI_NotificationManager Instance;

    [Header("References")]
    public Transform notificationParent;      // Vertical layout group parent
    public GameObject notificationPrefab;     // Prefab you created

    [Header("Settings")]
    public float lifetime = 2f;               // Time before notification disappears

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowNotification(Sprite icon, string itemName, int quantity)
    {
        GameObject notifObj = Instantiate(notificationPrefab, notificationParent);
        UI_NotificationDrop notif = notifObj.GetComponent<UI_NotificationDrop>();

        notif.Setup(itemName, icon , quantity);

        // Destroy notification after the lifetime
        Destroy(notifObj, lifetime);
    }
}
