using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public int redCol = 250, greenCol = 250, blueCol = 250;
    public GameObject gun;

    //GameObject selectedObject;
    bool lookingAtObject = false;
    bool flashingIn = true;
    bool startedFlashing = false;

    private void Start()
    {
        gun = GameObject.Find("Gun");
    }


    // Update is called once per frame
    void Update()
    {
        if (lookingAtObject)
        {
            gun.GetComponent<GunController>().selectedObject = gameObject.transform.parent.gameObject;
            GetComponent<SpriteRenderer>().color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("looking");
        lookingAtObject = true;
        if (!startedFlashing)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());

        }
    }

    private void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.15f);
            if (flashingIn)
            {
                if (redCol <= 127)
                    flashingIn = false;
                else
                {
                    redCol -= 25;
                    greenCol -= 25;
                    blueCol -= 25;
                }
            }
            else
            {
                if (redCol >= 250)
                    flashingIn = true;
                else
                {
                    redCol += 25;
                    greenCol += 25;
                    blueCol += 25;
                }
            }
        }
    }
}
