using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    private int uniqueNum;

    // Start is called before the first frame update
    void Start()
    {
        uniqueNum = Random.Range(0, 101);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
