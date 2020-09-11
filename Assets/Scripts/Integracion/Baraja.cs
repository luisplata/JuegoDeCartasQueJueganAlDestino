using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraja : MonoBehaviour
{
    [SerializeField] private List<Carta> cartas;

    public Carta TomarCarta()
    {
        int random = Random.Range(0, cartas.Count-1);
        Carta resultado = cartas[random];
        //cartas.RemoveAt(random);//Se acaban descomentado//nunca se acaban comentado
        return resultado;
    }
}
