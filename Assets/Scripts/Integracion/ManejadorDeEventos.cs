using Assets.Scripts.Excepciones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeEventos : MonoBehaviour
{
    [SerializeField] private List<Evento> listaDeEventos;
    [SerializeField] private AudioSource source;
    private Evento eventoActual;
    private Evento eventoReferencia;
    private GameObject referencia;
    private void Awake()
    {
        referencia = new GameObject();
        if (eventoActual == null)
        {
            eventoActual = listaDeEventos[0];
            //instanciamos
            eventoActual = Instantiate(eventoActual, referencia.transform);
            //mostramos la escena
            eventoActual.ComenzarEscena();
            source.clip = eventoActual.Sonido;
            source.loop = true;
            source.Play();
        }
    }


    public async void SiguienteEscena(Carta carta)
    {
        //comprobar primero miramos si tenemos escena cargada
        if (eventoActual == null)
        {
            eventoActual = listaDeEventos[0];
            //instanciamos
            eventoActual = Instantiate(eventoActual, referencia.transform);
            //mostramos la escena
            eventoActual.ComenzarEscena();
            source.clip = eventoActual.Sonido;
            source.loop = true;
            source.Play();
        }
        else
        {
            await eventoActual.TerminarEscena();
            eventoReferencia = eventoActual.SiguienteEvento(carta);
            if(eventoReferencia == null)
            {
                return;
                throw new SiguienteEventoNotFoundException("No hay mas eventos");
            }
            //destruimos el game object
            Destroy(eventoActual.gameObject);
            //construimos el siguiente escenario
            eventoActual = Instantiate(eventoReferencia, referencia.transform);
            //mostramos la escena
            eventoActual.ComenzarEscena();
            source.clip = eventoActual.Sonido;
            source.loop = true;
            source.Play();
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
