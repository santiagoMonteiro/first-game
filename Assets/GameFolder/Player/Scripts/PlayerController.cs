using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour // defining class and heritage
{
    private Rigidbody2D rigidBody;
    private Vector2 velocity;
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;

    public int life;
    public bool canJump;
    public float dashTime;
    public int comboNumber;
    public float comboTime;
    
    public Transform floorCollider;
    public Transform skin;
    public Animator skinAnimator;
    public LayerMask floorLayer;

    public string currentLevel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        skinAnimator = skin.GetComponent<Animator>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }
        
        life = GetComponent<Character>().life;
        velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 7, rigidBody.velocity.y);
        dashTime += Time.deltaTime;
        comboTime += Time.deltaTime;
        
        canJump = Physics2D.OverlapCircle(
            floorCollider.position,
            0.2f * 6,
            floorLayer);
        
        if (life <= 0)
        {
            rigidBody.simulated = false;
            enabled = false;
        }

        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            audioSource.PlayOneShot(dashSound, 0.3f);
            dashTime = 0;
            skinAnimator.Play("PlayerDash", -1);
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(skin.localScale.x * 100 * 7, 0));
        }

        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNumber++;
            if (comboNumber > 2)
            {
                comboNumber = 1;
            }

            comboTime = 0;
            skinAnimator.Play("PlayerAttack" + comboNumber, -1);

            if (comboNumber == 1)
            {
                audioSource.PlayOneShot(attack1Sound, 1f);
            }
            else
            {
                audioSource.PlayOneShot(attack2Sound, 0.8f);
            }
        }

        if (comboTime >= 1)
        {
            comboNumber = 0;
        }

        if (canJump && Input.GetButtonDown("Jump"))
        {
            skinAnimator.Play("PlayerJump", -1);
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, 150 * 7));
        }
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skinAnimator.SetBool("PlayerRun", true);
        }
        else
        {
            skinAnimator.SetBool("PlayerRun", false);
        }
    }

    private void FixedUpdate()
    {
        if (dashTime > 0.5f)
        {
            rigidBody.velocity = velocity;
        }
    }
}