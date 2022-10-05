using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    private Transform player;

    public Transform skin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skin.GetComponent<Animator>().Play("Stuck", -1);
            
            player = collision.transform;
            player.position = transform.position;

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            player.GetComponent<PlayerController>()
                .skin.GetComponent<Animator>()
                .SetBool("PlayerRun", false);
            
            player.GetComponent<PlayerController>()
                .skin.GetComponent<Animator>()
                .Play("PlayerIdle", -1);
            
            GetComponent<BoxCollider2D>().enabled = false;
            
            player.GetComponent<PlayerController>().enabled = false;
            
            Invoke("ReleasePlayer", 2);
        }
    }
}
