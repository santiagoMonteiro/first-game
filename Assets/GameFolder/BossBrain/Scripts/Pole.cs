using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public Transform spike;
    public AudioClip sound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("AttackCollider"))
        {
            spike.GetComponent<Animator>().Play("Spike", -1);
            GetComponent<Animator>().Play("Pole");
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
