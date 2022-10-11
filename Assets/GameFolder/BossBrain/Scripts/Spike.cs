using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public AudioClip sound;
    private Transform boss;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            boss = collision.transform;
            collision.GetComponent<BossController>().enabled = false;
            boss.parent = transform;
            boss.localPosition = Vector3.zero;
        }
    }

    public void CollisionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }

    public void ReleaseBoss()
    {
        if (boss != null)
        {
          boss.GetComponent<BossController>().enabled = true;
          boss.parent = null;  
        }
        
    }
}
