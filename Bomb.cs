using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dog" || collision.tag == "Farmer")
        {
            Destroy(gameObject);
        }
    }
}
