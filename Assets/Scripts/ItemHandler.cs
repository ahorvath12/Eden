using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public int index;
    public KeyCode key;
    public bool startHighlighted = false;
    public KeyCode[] otherKeys;

    private Button button;
    private GameObject gun;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    
    void Start()
    {
        gun = GameObject.Find("Gun");
        if (startHighlighted)
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
    }
    
    void Update()
    {
        // change to this button
        if (Input.GetKeyDown(key))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
            gun.GetComponent<GunController>().ChangeItem(index);
        }
        //other button is active
        else if (Input.GetKeyDown(otherKeys[0]) || Input.GetKeyDown(otherKeys[1]) || Input.GetKeyDown(otherKeys[2]))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    //allow changing of button color when active
    private void FadeToColor (Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
