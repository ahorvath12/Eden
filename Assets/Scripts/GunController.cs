using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] prefabs;

    private Vector3 playerPos, playerDir;
    private Quaternion playerRotation;
    float spawnDistance = 10;

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

        if (Input.GetKeyDown("space"))
        {
            GameObject prefab = Instantiate(prefabs[0], spawnPos, playerRotation);
           Vector3 temp = prefab.transform.position;
            temp.y = prefabs[0].transform.position.y;
            prefab.transform.position = temp;
        }
    }
}
