using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public Text heartCountText;
    
    private Animator skinAnimator;
    
    void Start()
    {
        skinAnimator = skin.GetComponent<Animator>();
    }

    void Update()
    {
        if (life <= 0)
        {
            skinAnimator.Play("Die", -1);
        }

        if (heartCountText)
        {
            heartCountText.text = "x" + life.ToString();
        }
    }

    public void PlayerDamage( int damage )
    {
        if (life > 0)
        {
            life -= damage;
            skinAnimator.Play("PlayerDamage", 1);
            cam.GetComponent<Animator>().Play(
                "CameraPlayerDamage", -1);
            
            GetComponent<PlayerController>().audioSource
                .PlayOneShot(GetComponent<PlayerController>().damageSound, 0.5f);
        }
    }
}
