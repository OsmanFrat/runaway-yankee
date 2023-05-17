using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public bool canDoubleJump;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private GameManager gameManager;
    public bool doubleTime = true;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {   
            
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            canDoubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canDoubleJump = false;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && !gameOver && doubleTime)
        {
            Time.timeScale = 1.5f;
            doubleTime = false;
            
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && !doubleTime && !gameOver)
        {
            Time.timeScale = 1.0f;
            doubleTime = true;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
       if(collision.gameObject.CompareTag("Ground"))
       {
            isOnGround = true;
            dirtParticle.Play();
       }
       else if(collision.gameObject.CompareTag("Obstacle"))
       {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            
       }
       

    }
}
