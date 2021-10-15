using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerStart : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
