using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap2Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
