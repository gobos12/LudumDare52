using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public static Currency singleton;

    public TMP_Text moneyText;
    public int myMoney = 0;

    private void Start()
    {
        singleton = this;
        moneyText.text = "$" + myMoney.ToString();
    }

    public void AddMoney(int amount)
    {
        myMoney += amount;
        moneyText.text = "$" + myMoney.ToString();
    }

}
