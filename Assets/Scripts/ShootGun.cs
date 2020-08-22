﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject player, spawnPos;
    public float spawnDist;

    private Rigidbody cannonballInstance;

    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        RaycastHit hitInfo;
    //        if (Physics.Raycast(ray, out hitInfo))
    //        {
    //            FireCannonAtPoint(hitInfo.point);
    //        }
    //    }
    //}

    public void ReceiveCommand(GameObject prefab)
    {
        cannonballInstance = prefab.GetComponent<Rigidbody>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            FireCannonAtPoint(hitInfo.point);
        }
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        //Vector3 tempTransform = player.transform.position;
        //Vector3 tempDir = player.transform.forward;
        //Vector3 spawnPos = tempTransform + tempDir * spawnDist;
        //cannonballInstance.transform.position = spawnPos;
        cannonballInstance.transform.position = spawnPos.transform.position;
        cannonballInstance.velocity = velocity;
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }

    
}