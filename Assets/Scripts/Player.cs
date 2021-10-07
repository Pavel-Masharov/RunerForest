using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private float jumpForcePlayer;
    private bool isGround = true;
    private float xRange = 1.5f;
    private Rigidbody rbPlayer;

    private Animator playerAnim;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource playerAudio;

    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private ParticleSystem explorationParticle;
    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        rbPlayer = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnim.SetFloat("Speed_f", 0f);
    }
    private void Update()
    {
        if(GameManager.isGameOver == false)
        {
            PlayerTurn();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpPlayer();
            }
        }
    }

    private void PlayerTurn()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
       
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.Lerp(transform.position, new Vector3(-1.5f,0,0), 1));

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.Lerp(transform.position, new Vector3(1.5f, 0, 0), 1));
        }
    }

    private void JumpPlayer()
    {
        if(isGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForcePlayer, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            playerAnim.SetFloat("Speed_f", 1f);
            isGround = true;
        }
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            explorationParticle.Play();
            dirtParticle.Pause();
            gameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monet"))
        {
            Destroy(other.gameObject);
            GameManager.monets++;
        }
    }
}
