using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Manager : MonoBehaviour
{
    public int coin_count;
    public int coin_goal;
    public TMP_Text coin_text_owned;
    public TMP_Text coin_text_goal;


    void Update()
    {
        SetMoney();
    }

    public void SetMoney()
    {
        coin_text_owned.text = "Doubloons: " + coin_count.ToString();
        coin_text_goal.text = "Goal: " + coin_goal.ToString();
    }
}
