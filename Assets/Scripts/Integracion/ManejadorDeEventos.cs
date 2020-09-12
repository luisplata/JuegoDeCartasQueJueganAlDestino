using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeEventos : MonoBehaviour
{
    [SerializeField] private List<Evento> listaDeEventos;
    private Evento eventoActual;
    private Evento eventoReferencia;
    private GameObject referencia;
    private void Awake()
    {
        referencia = new GameObject();
    }

    public void SiguienteEscena(Carta carta)
    {
        //comprobar primero miramos si tenemos escena cargada
        if (eventoActual == null)
        {
            eventoActual = listaDeEventos[0];
            //instanciamos
            eventoActual = Instantiate(eventoActual, referencia.transform);
            //mostramos la escena
            eventoActual.ComenzarEscena();
        }
        else
        {
            eventoReferencia = eventoActual.SiguienteEvento(carta);
            eventoActual.TerminarEscena();
            //destruimos el game object
            Destroy(eventoActual.gameObject);
            //construimos el siguiente escenario
            eventoActual = Instantiate(eventoReferencia, referencia.transform);
            //mostramos la escena
            eventoActual.ComenzarEscena();
        }
    }

    public void SiguienteEscenaTutorial()
    {
        Debug.Log("Carga la escena del tutorial");
        eventoActual = listaDeEventos[0];
        //instanciamos
        eventoActual = Instantiate(eventoActual, referencia.transform);
        //mostramos la escena
        eventoActual.ComenzarEscena();
    }
}
