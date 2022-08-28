using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private PlayerController playerController;

    private AudioSource source;
    public AudioClip doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && playerController.key == 1) // The Door will open once the player obtains the key
        {
            source.PlayOneShot(doorOpen, 1.0f);
            Debug.Log("You Open the door!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Door is locked, you need a key"); // No key = Door stays closed
        }
    }

}