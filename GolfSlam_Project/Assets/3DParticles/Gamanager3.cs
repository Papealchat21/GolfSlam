using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamanager3 : MonoBehaviour
{
    public ParticleController intento;
    public PlayerController score;
    public GameObject disparoListo;
    public GameObject botonReiniciar;

    private void Start()
    {
        disparoListo.SetActive(true);
        botonReiniciar.SetActive(false);
    }

    private void Update()
    {
        if (intento.intentos >= 5)
        {
            disparoListo.SetActive(false);
            if (intento.intentos == 6)
            {
                Time.timeScale = 0;
                botonReiniciar.SetActive(true);
            }
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
