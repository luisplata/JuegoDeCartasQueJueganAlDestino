﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPausa : MonoBehaviour
{
    public bool estaPausado;

    public GameObject menuDePausa;
    public GameObject menuDeOpciones;

    ControladorMenuOpciones controladorMenuOpciones;

    private void Start()
    {
        controladorMenuOpciones = GetComponent<ControladorMenuOpciones>();
        controladorMenuOpciones.menuOpcionesActivo = true;
    }
    // Start is called before the first frame update
    void Update()
    {
        Debug.Log(controladorMenuOpciones.menuOpcionesActivo);
        //si hacemos click en la tecla ESC nos saldrá el menú de escape
        if (Input.GetKeyDown(KeyCode.Escape) && controladorMenuOpciones.menuOpcionesActivo == true)
        {
            ponerPausaAlJuego();

        }
    }
    //Vamos a pausar el juego 
    public void ponerPausaAlJuego()
    {
        if (!estaPausado)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        estaPausado = !estaPausado;
        menuDePausa.SetActive(menuDePausa);
    }
    public void AbrirMenuOpciones()
    {
        menuDePausa.SetActive(false);
        menuDeOpciones.SetActive(menuDeOpciones);
        controladorMenuOpciones.menuOpcionesActivo = false;
    }
    public void quitarPausaAlJuego()
    {
        Time.timeScale = 1;
        menuDePausa.SetActive(false);

    }
    public void VolverAlMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
