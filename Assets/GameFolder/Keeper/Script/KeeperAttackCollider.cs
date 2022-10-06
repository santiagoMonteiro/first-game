using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision");

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
