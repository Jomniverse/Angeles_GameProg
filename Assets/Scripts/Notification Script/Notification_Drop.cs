using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Notification_Drop : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text itemNameText;
    public TMP_Text quantityText;

    public void Setup(Sprite icon, string itemName, int quantity)
    {
        iconImage.sprite = icon;
        itemNameText.text = itemName;
        quantityText.text = "+ " + quantity.ToString();
    }
}
