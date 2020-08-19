using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public KeyCode key;
    public bool startHighlighted = false;
    public KeyCode[] otherKeys;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startHighlighted)
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyDown(otherKeys[0]) || Input.GetKeyDown(otherKeys[1]) || Input.GetKeyDown(otherKeys[2]))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    private void FadeToColor (Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
