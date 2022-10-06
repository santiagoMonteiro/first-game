using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip groundedSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            audioSource.PlayOneShot(groundedSound, 0.3f);
        }
    }
}
