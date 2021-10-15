using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger2 : MonoBehaviour
{
    public ParticleController intento;
    public PlayerController score;
    public GameObject disparoListo;
    public GameObject pressSpace;

    private void Start()
    {
        disparoListo.SetActive(true);
        pressSpace.SetActive(false);
    }

    private void Update()
    {
        if (intento.intentos >= 5)
        {
            disparoListo.SetActive(false);
            pressSpace.SetActive(true);
            if (intento.intentos == 6)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
