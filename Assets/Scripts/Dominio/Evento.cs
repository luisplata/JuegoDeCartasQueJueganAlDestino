using Assets.Scripts.Excepciones;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Evento : MonoBehaviour
{
    [SerializeField] private TiposElegibles tipo;
    [SerializeField] public List<Evento> eventosSiguientes;
    [SerializeField] private bool esElEventoFinal, esElTutorial;
    [SerializeField] private GameObject escenaMontada;
    [SerializeField] private AudioClip sonidoDeEvento;
    public void ComenzarEscena()
    {
        escenaMontada = Instantiate(escenaMontada, transform);
        escenaMontada.SetActive(true);
        escenaMontada.GetComponent<Escenario>().PrimerActo();
    }

    public AudioClip Sonido => sonidoDeEvento;

    public async Task TerminarEscena()
    {
        //si es el evento final y estamos en el tutorial nos vamos a la siguiente escena
        if (esElEventoFinal && esElTutorial)
        {
            GameObject.Find("ManejadorDeEventos").GetComponent<MostrarTexto>().barajaImage.enabled = false;
            GameObject.Find("ManejadorDeEventos").GetComponent<MostrarTexto>().textoTutorial.gameObject.SetActive(false);
            GameObject.Find("ManejadorDeEventos").GetComponent<MostrarTexto>().panelFondoTutorial.gameObject.SetActive(false);
        }
        await escenaMontada.GetComponent<Escenario>().UltimoActo();
    }

    public bool FinalizoElUltimoActo => escenaMontada.GetComponent<Escenario>().FinalizoLaAnimacion;

    public Evento SiguienteEvento(CartaGenerica carta)
    {
        //si es el evento final y estamos en el tutorial nos vamos a la siguiente escena
        if (esElEventoFinal && esElTutorial)
        {
            SceneManager.LoadScene("Game");
            return null;
        }
        if (eventosSiguientes.Count <= 0)
        {
            throw new SiguienteEventoNotFoundException("El evento " + gameObject.name + " no tiene eventos siguiente");
        }
        Evento resultado = null;

        foreach (Evento e in eventosSiguientes)
        {
            if (e.tipo == carta.Tipo)
            {
                resultado = e;
                break;
            }
        }
        if (resultado == null)
        {
            throw new Exception("no encontramos el escenario siguiente");
        }
        return resultado;
    }
}
