using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public void EntrarCinematica()
    {
        SceneManager.LoadScene("Cinematica");
    }

    public void EntrarAlTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void EntrarAlJuego()
    {
        SceneManager.LoadScene("Game");
    }
}
