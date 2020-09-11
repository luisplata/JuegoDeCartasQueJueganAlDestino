using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    [SerializeField] private TiposElegibles tipo;
    [SerializeField] private List<Evento> eventosSiguientes;
    [SerializeField] private bool esElEventoFinal;
}
