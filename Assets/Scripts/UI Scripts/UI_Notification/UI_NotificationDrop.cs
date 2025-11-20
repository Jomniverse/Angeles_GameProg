using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_NotificationDrop : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemNameText;
    public TMP_Text quantityText;

    // Assign info when created
    public void Setup(string name, Sprite sprite, int quantity)
    {
        itemNameText.text = name;
        quantityText.text = "x" + quantity.ToString();
        icon.sprite = sprite;
    }
}