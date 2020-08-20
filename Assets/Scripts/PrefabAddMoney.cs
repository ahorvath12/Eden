using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabAddMoney : MonoBehaviour
{
    public GameObject MoneyCounter;
    public int toAdd;
    public float waitPeriod = 2f;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        MoneyCounter = GameObject.FindWithTag("MoneyCounter");
        text = MoneyCounter.GetComponent<Text>();
        StartCoroutine("AddMoney", waitPeriod);
    }

    IEnumerator AddMoney(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitPeriod);
            text.GetComponent<WalletManager>().AddAmount(toAdd);
        }
    }
}
