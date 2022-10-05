using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>()
                .velocity = Vector2.zero;
            
            collision.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(0, 200));

            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
