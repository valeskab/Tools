using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [Header ("Player Health")]
    public int curHP;
    public int maxHP;

    public HealthBar healthBar;


    [Header("PlayerStats")]
    public float speed;
    public float jumpHeight;
    private Rigidbody2D rb;

     [Header("Inventory")]
    public int key;
    public int coins;
    public int moonstone;

    [Header("GroundCheck")]
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private float moveVelocity;

    private Vector3 respawnPoint;
    public GameObject fallDetector;


    public AudioClip marker;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>(); //Loading the rigidbody

        curHP = maxHP;
        healthBar.SetHealth(maxHP);

        source = GetComponent<AudioSource>();

        respawnPoint = transform.position; //store position of player before first frame
    }

    void Update()
    {
        //Ground check sensor, This is going to make the radius go in a circle to check if the player is touching the ground.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
        
        // Non-stick Player
        moveVelocity = 0f;

        if(Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }

        // Move player left and right
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        //Get key down only registers it once, get key would only go down permanently
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector") // Detecting when the player is passing thru the Fall detector
        {
            transform.position = respawnPoint; // Change position to respawn point
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        source.PlayOneShot(marker, 1.0f);
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        //Updates the health bar using current Health
        healthBar.SetHealth(curHP);

        if(curHP <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Player has been defeated!");
        transform.position = respawnPoint; // Change position to respawn point
    }

    
}