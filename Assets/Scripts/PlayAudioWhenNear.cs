using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioWhenNear : MonoBehaviour
{
    private GameObject player;
    private AudioSource audioSource;
    private bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) <= 10f)
        {
            if (!hasPlayed)
            {
                hasPlayed = true;
                audioSource.Play();
            }
        }
        else if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) > 10f)
        {
            hasPlayed = false;
        }
    }
}
