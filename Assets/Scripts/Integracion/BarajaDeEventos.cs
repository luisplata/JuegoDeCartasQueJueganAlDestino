using System.Collections.Generic;
using UnityEngine;

public class BarajaDeEventos : MonoBehaviour
{
    [SerializeField] protected List<CartaDeEvento> cartas;

    public virtual CartaDeEvento TomarCarta()
    {
        int random = Random.Range(0, cartas.Count - 1);
        CartaDeEvento resultado = cartas[random];
        //cartas.RemoveAt(random);//Se acaban descomentado//nunca se acaban comentado
        return resultado;
    }
}
