using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public TMP_Text moneyText;
    public int myMoney = 0;

    private void Start()
    {
        moneyText.text = "$" + myMoney.ToString();
    }

}
