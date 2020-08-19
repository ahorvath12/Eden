using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] buttonObjects;

    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new Button[buttonObjects.Length];

        for (int i = 0; i < buttons.Length; i++)
            buttons[i] = buttonObjects[i].GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
