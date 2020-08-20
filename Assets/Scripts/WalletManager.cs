using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletManager : MonoBehaviour
{
    public int maxMoney = 9999;

    private Text text;
    private int currentMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAmount(int amount)
    {
        if (amount + currentMoney < maxMoney)
        {
            currentMoney = amount + currentMoney;
        }
        else
        {
            currentMoney = maxMoney;
        }
        text.text = currentMoney.ToString();

    }

    public void SubtractAmount(int amount)
    {
        currentMoney = currentMoney - amount;
        text.text = currentMoney.ToString();
    }
}
