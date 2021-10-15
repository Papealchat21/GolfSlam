using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody playerRB;
    public float speed = 5f;

    public GameObject cannon;
    public Text puntuacionText;

    public Camera FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;

    public float angulo;

    public int puntuacion;

    public void Start()
    {
        puntuacion = 0;
        playerRB = GetComponent<Rigidbody>();
        Debug.Log(puntuacion);
    }

    // Update is called once per frame
    void Update()
    {
        puntuacionText.GetComponent<Text>().text = "" + puntuacion;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float mouseX = horizontalSpeed * Input.GetAxis("Mouse X");


        if (horizontal != 0.0f || vertical != 0.0f)
        {
            transform.Rotate(0, horizontal, 0);
        }
    }
}

