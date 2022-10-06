using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Transform player;
    public float attackTime;
    
    void Start()
    {
        attackTime = 0;
    }

    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            enabled = false;
        }
        
        if (Vector2.Distance(transform.position, player.position) > 0.9f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                6f * Time.deltaTime);
        }
        else
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 0.6f)
            {
                attackTime = 0;
                player.GetComponent<Character>().life--;
                player.GetComponent<Character>().PlayerDamage(1);
            }
        }
        
    }   
}
