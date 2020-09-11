using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public void ComenzarPartida()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
