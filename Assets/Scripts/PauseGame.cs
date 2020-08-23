using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{
    public GameObject[] buttonObjects;
    public GameObject player, gun;

    private Button[] buttons;
    private bool paused = false;
    private int buttonIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gun = GameObject.Find("Gun");
        buttons = new Button[buttonObjects.Length];

        for (int i = 0; i < buttonObjects.Length; i++)
        {
            buttons[i] = buttonObjects[i].GetComponent<Button>();
        }

        GetComponent<Image>().enabled = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseAll(true);
                Time.timeScale = 0f;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PauseAll(false);
                Time.timeScale = 1f;
            }
            buttonIndex = 0;
        } 
       
    }

    public void PauseAll(bool pause)
    {
        player.GetComponent<FirstPersonController>().enabled = !pause;
        gun.GetComponent<GunController>().enabled = !pause;
        GetComponent<Image>().enabled = pause;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(pause);
        }
    }
    
    
    public void Resume()
    {
        PauseAll(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
