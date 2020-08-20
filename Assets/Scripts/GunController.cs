using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] prefabs;
    public GameObject selectedObject;

    private Vector3 playerPos, playerDir;
    private Quaternion playerRotation;
    float spawnDistance = 10;
    int inventoryIndex = 0;

    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        playerDir = player.transform.forward;
        playerRotation = player.transform.rotation;
        spawnPos = playerPos + playerDir * spawnDistance;

        //shoot item
        if (Input.GetMouseButtonDown(0))
        {
            GameObject prefab = Instantiate(prefabs[inventoryIndex], spawnPos, playerRotation);
           Vector3 temp = prefab.transform.position;
            temp.y = prefabs[inventoryIndex].transform.position.y;
            prefab.transform.position = temp;
        }
        else if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Destroy(selectedObject);
        }
    }

    public void ChangeItem(int index)
    {
        inventoryIndex = index;
    }
}
