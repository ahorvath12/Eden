using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Vector3 dest)
    {
        transform.position = dest;
    }
}
