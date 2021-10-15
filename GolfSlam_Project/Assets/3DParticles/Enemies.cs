using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            Destroy(enemy);
            Destroy(gameObject);
        }
    }
}
