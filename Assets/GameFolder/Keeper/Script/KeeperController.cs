using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform skin;
    public Transform keeperRange;
    public Animator skinAnimator;

    public AudioSource audioSource;
    public AudioClip dieSound;

    public bool goRight;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        skinAnimator = skin.GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(dieSound, 0.5f);
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            enabled = false;
        }
        
        if (skinAnimator.GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }
        
        if (goRight)
        {
            skin.localScale = new Vector3(1, 1, 1);
            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }
            transform.position = Vector2.MoveTowards(
                transform.position, 
                b.position,
                10 * 0.2f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }
            transform.position = Vector2.MoveTowards(
                transform.position, 
                a.position,
                10 * 0.2f * Time.deltaTime);
        }
        
    }
}
