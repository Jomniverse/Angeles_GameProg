using UnityEngine;

public class Customer_OpenWant : MonoBehaviour
{
    public GameObject panel_Want;
    public void OpenWant()
    {
        panel_Want.SetActive(true);
    }

    public void CloseWant()
    {
        panel_Want.SetActive(false);
    }
}
