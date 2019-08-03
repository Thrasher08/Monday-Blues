using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyCars : MonoBehaviour
{
    
    public void DestroyCars()
    {
        foreach (Transform enemy in this.transform)
        {
            GameObject.Destroy(enemy.gameObject);
        }
    }

}
