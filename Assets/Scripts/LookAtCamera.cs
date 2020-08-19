using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera m_Camera;

    private void Start()
    {
        GameObject playerCamera = GameObject.FindWithTag("MainCamera");
        m_Camera = playerCamera.GetComponent<Camera>();
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
