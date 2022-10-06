using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int comboNum = player.GetComponent<PlayerController>().comboNumber;
            collision.GetComponent<Character>().life -= comboNum;
        }
    }
}
