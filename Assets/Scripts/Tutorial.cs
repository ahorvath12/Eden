using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject click1, click2, nums,collect;
    public float waitTime;

    private bool hasClicked1, hasClicked2, hasSeenNums, moveToCoin,hasSeenCollect, endTutorial;
    private float lastTimeChecked;

    // Start is called before the first frame update
    void Start()
    {
        click1.SetActive(false);
        click2.SetActive(false);
        nums.SetActive(false);
        collect.SetActive(false);
        lastTimeChecked = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endTutorial)
        {
            if (!hasClicked1 && HasTimePassed())
            {
                click1.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    hasClicked1 = true;
                    click1.SetActive(false);
                    lastTimeChecked = Time.time;
                }
            }
            else if (hasClicked1 && !hasClicked2 && HasTimePassed())
            {
                click2.SetActive(true);
                if (Input.GetMouseButtonDown(1))
                {
                    hasClicked2 = true;
                    click2.SetActive(false);
                    lastTimeChecked = Time.time;
                }
            }
            else if (hasClicked2 && !hasSeenNums && HasTimePassed())
            {
                hasSeenNums = true;
                nums.SetActive(true);
                waitTime = 4;
                lastTimeChecked = Time.time;
            }
            else if (hasSeenNums && !moveToCoin && HasTimePassed())
            {
                moveToCoin = true;
                waitTime = 2;
                nums.SetActive(false);
                lastTimeChecked = Time.time;
            }
            else if (hasSeenNums && moveToCoin && !hasSeenCollect && HasTimePassed())
            {
                Debug.Log("collect");
                waitTime = 4;
                collect.SetActive(true);
                hasSeenCollect = true;
                lastTimeChecked = Time.time;
            }
            else if (hasSeenCollect && HasTimePassed())
            {
                hasSeenCollect = false;
                collect.SetActive(false);
                endTutorial = true;
            }
        }
        
    }

    private bool HasTimePassed()
    {
        return Time.time - lastTimeChecked > waitTime;
    }
}
