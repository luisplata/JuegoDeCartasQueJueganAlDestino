using Assets.Scripts.Excepciones;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Evento : MonoBehaviour
{
    [SerializeField] private TiposElegibles tipo;
    [SerializeField] private List<Evento> eventosSiguientes;
    [SerializeField] private bool esElEventoFinal;
    [SerializeField] private GameObject escenaMontada;
    public void ComenzarEscena()
    {
        escenaMontada = Instantiate(escenaMontada, transform);
        escenaMontada.SetActive(true);
        escenaMontada.GetComponent<Escenario>().PrimerActo();
    }

    public void TerminarEscena()
    {
        escenaMontada.GetComponent<Escenario>().UltimoActo();
    }

    public bool FinalizoElUltimoActo => escenaMontada.GetComponent<Escenario>().FinalizoLaAnimacion;

    public Evento SiguienteEvento(Carta carta)
    {
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
