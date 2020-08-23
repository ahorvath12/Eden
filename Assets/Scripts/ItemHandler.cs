using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public GameObject cross, outline, wallet;
    public int index, val;
    public KeyCode key;
    public bool startHighlighted = false;
    public KeyCode[] otherKeys;

    private Button button;
    private GunController gun;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<GunController>();
        outline.SetActive(false);
        if (startHighlighted)
        {
            FadeToColor(button.colors.pressedColor);
            outline.SetActive(true);
            button.onClick.Invoke();
            gun.ChangeItem(index, val);
        }
    }
    
    void Update()
    {
        // change to this button
        if (Input.GetKeyDown(key))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
            gun.ChangeItem(index, val);
            outline.SetActive(true);
        }
        //other button is active
        else if (Input.GetKeyDown(otherKeys[0]) || Input.GetKeyDown(otherKeys[1]) || Input.GetKeyDown(otherKeys[2]))
        {
            outline.SetActive(false);
            FadeToColor(button.colors.normalColor);
        }

        //cross out item if wallet amount is too low
        if (wallet.GetComponent<WalletManager>().GetBalance() < val)
            cross.SetActive(true);
        else
            cross.SetActive(false);
    }

    //allow changing of button color when active
    private void FadeToColor (Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
