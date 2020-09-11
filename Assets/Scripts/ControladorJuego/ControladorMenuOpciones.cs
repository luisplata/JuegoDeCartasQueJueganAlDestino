using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMenuOpciones : MonoBehaviour
{
    public GameObject menuDeOpciones;
    public GameObject menuDePausa;
    [SerializeField] public bool menuOpcionesActivo;
    ControladorMenuPausa controladorMenuPausa;

    public float rbgValue = 0.5f;

    private void Start()
    {
        controladorMenuPausa = GetComponent<ControladorMenuPausa>();
    }

    public void VolverAlMenuPrincipal()
    {
        controladorMenuPausa.estaPausado = true;
        menuOpcionesActivo = true;
        menuDeOpciones.SetActive(false);
        menuDePausa.SetActive(true);
    }
}
