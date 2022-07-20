using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money = 10;

    Text moneytext;

    // Start is called before the first frame update
    void Start()
    {
        moneytext = GameObject.Find("MoneyText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = "$ " + money.ToString();
    }

    public int Moneyy()
    {
        return money;
    }

    public void ModifyMoney(int _money)
    {
        money += _money;
        money = Mathf.Clamp(money, 0, 999);
    }
}
