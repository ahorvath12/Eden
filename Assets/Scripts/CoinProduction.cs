using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinProduction : MonoBehaviour
{
    public GameObject player, coinCounter, instructions;
    public int amount;

    private Renderer rend;
    private int productionTime, coinAmount;
    string tagName;

    bool canHarvest;
    float lastTimeChecked;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        coinCounter = GameObject.FindWithTag("MoneyCounter");

        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        instructions.GetComponent<Text>().enabled = false;
        tagName = transform.parent.tag;

        switch (tagName) {
            case "House":
                productionTime = Random.Range(120, 150);
                coinAmount = 200;
                break;
            case "Human":
                productionTime = Random.Range(80, 120);
                coinAmount = 100;
                break;
            case "Husbandry":
                productionTime = Random.Range(80, 120);
                coinAmount = 150;
                break;
        }
        lastTimeChecked = Time.time;
    }

    private void Update()
    {
        if (HarvestReady())
        {
            rend.enabled = true;
        }

        if (canHarvest && HarvestReady())
        {
            instructions.GetComponent<Text>().enabled = true;

            if (Input.GetKeyDown("e"))
            {
                coinCounter.GetComponent<WalletManager>().AddAmount(coinAmount);
                lastTimeChecked = Time.time;
                rend.enabled = false;

                GetComponent<AudioSource>().Play();
                instructions.GetComponent<Text>().enabled = false;
            }
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            canHarvest = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            canHarvest = false;
    }

    private bool HarvestReady()
    {
        return Time.time - lastTimeChecked > productionTime;
    }
}
 