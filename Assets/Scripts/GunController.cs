using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject player, gameManager;
    public GameObject[] prefabs;
    public GameObject selectedObject;

    private GameObject moneyCounter;
    private Vector3 playerPos, playerDir;
    private Quaternion playerRotation;
    float spawnDistance = 10;
    int inventoryIndex = 0, cost;
    int[] spawnPoints = new int[] { 1, 6, 20, 40 };

    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        moneyCounter = GameObject.FindWithTag("MoneyCounter");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        playerDir = player.transform.forward;
        playerRotation = player.transform.rotation;
        spawnPos = playerPos + playerDir * spawnDistance;

        //shoot item
        if (Input.GetMouseButtonDown(0) && cost < moneyCounter.GetComponent<WalletManager>().GetBalance())
        {
            GameObject prefab = Instantiate(prefabs[inventoryIndex], spawnPos, playerRotation);
            Vector3 temp = prefab.transform.position;
            temp.y = prefabs[inventoryIndex].transform.position.y;
            prefab.transform.position = temp;
            gameManager.GetComponent<EnvironmentManager>().UpdateIndex(spawnPoints[inventoryIndex]);
            moneyCounter.GetComponent<WalletManager>().SubtractAmount(cost);
        }
        //remove item
        else if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Destroy(selectedObject);
            gameManager.GetComponent<EnvironmentManager>().UpdateIndex(-1 * spawnPoints[inventoryIndex]);
        }
    }

    public void ChangeItem(int index, int val)
    {
        inventoryIndex = index;
        cost = val;
    }
}
