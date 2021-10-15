using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaAmarilla : MonoBehaviour
{
    public PlayerController score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            score.puntuacion = score.puntuacion + 2;
            Debug.Log(score.puntuacion);
            Destroy(collision.gameObject);
        }
    }
}
