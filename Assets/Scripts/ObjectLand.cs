using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLand : MonoBehaviour
{
    private Vector3 originalScale;

    private bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        inAir = true;
        originalScale = transform.localScale;
        transform.localScale = new Vector3(.1f, .1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (inAir && transform.localScale.y < originalScale.y)
        {
            transform.localScale += new Vector3(.5f, .5f, .5f) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().detectCollisions = false;
            GetComponent<BoxCollider>().enabled = false;
            inAir = false;
        }
    }
}
