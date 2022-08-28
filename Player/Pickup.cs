using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Pickuptype {Key, Coins, Moonstone};
    public Pickuptype currentPickup;

    public int pickupAmount = 10;
    
    private PlayerController playerController;
    
    public ScoreManager scoreManager; // A variable to reference the ScoreManager

    private AudioSource source;
    public AudioClip coinPickup;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(currentPickup == Pickuptype.Key)
            {
                playerController.key = pickupAmount;

                Debug.Log("You have picked up a Golden Key!");
            }
            else if(currentPickup == Pickuptype.Coins)
            {
                source.PlayOneShot(coinPickup, 1.0f);
                playerController.coins += pickupAmount;
                Debug.Log("You have picked up" + pickupAmount + " Coins");

                scoreManager.IncreaseScoreText(pickupAmount); // Pickup script talking to the score manager
            }
            else if(currentPickup == Pickuptype.Moonstone)
            {
                playerController.moonstone += pickupAmount;
                Debug.Log("You have picked up" + pickupAmount + "Moonstone");
            }

            Destroy(gameObject);
        }
    }

}
