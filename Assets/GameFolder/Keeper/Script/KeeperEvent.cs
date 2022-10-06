using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound;

    public void KeeperAttackSound()
    {
        audioSource.PlayOneShot(attackSound, 0.8f);
    }
}
