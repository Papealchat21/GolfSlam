using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suelodestructor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Debug.Log("Fallaste");
            Destroy(collision.gameObject);
        }
    }
}
