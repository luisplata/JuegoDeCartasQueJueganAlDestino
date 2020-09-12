using Assets.Scripts.Excepciones;
using System.Collections.Generic;
using UnityEngine;

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

    public Evento SiguienteEvento()
    {
        if(eventosSiguientes.Count <= 0)
        {
            throw new SiguienteEventoNotFoundException("El evento " + gameObject.name + " no tiene eventos siguiente");
        }
        int indexDelSiguienteElemento = 0;
        return eventosSiguientes[indexDelSiguienteElemento];
    }
}
