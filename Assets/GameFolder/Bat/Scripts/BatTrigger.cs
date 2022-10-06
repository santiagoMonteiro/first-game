using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public Transform[] bat;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
