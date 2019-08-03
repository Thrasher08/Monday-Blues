using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZoneSCript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy Car")
        {
            Destroy(collision.gameObject);
        }
    }

}
