using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaVerde : MonoBehaviour
{
    public PlayerController score;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            score.puntuacion = score.puntuacion + 3;
            Debug.Log(score.puntuacion);
            Destroy(collision.gameObject);
        }
    }
}
