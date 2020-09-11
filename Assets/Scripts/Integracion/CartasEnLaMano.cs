using Assets.Scripts.Integracion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartasEnLaMano : MonoBehaviour
{
    public List<Carta> cartasDeLaMano;
    [SerializeField] private Baraja baraja;
    public GameObject referenciaDePosicionDeCarta;
    public List<GameObject> referenciasDeCartas;
    [SerializeField] private ClicksDeLaCarta click;
    [SerializeField] private bool TodasLascartasEnlaMano = false;

    public void TomarCartas()
    {
        //Limitamos el número de cartas que vamos a poder tener en la mano
        if (TodasLascartasEnlaMano == false)
        {
            Carta carta = baraja.TomarCarta();
            cartasDeLaMano.Add(carta);
            MostrarMano();

        }
        //Cuando tengamos 5 cartas en la mano no podremos tener más
        if (cartasDeLaMano.Count == 5)
        {
            TodasLascartasEnlaMano = true;
        }
        //Mientras que no tengamos las 5 cartas en la mano la booleana seguirá siendo false
        else
        {
            TodasLascartasEnlaMano = false;
        }

    }

    public void UsarCarta(Carta cartaUtilizada)
    {
        /*foreach (Carta c in cartasDeLaMano)
        { 
            if(c.Nombre == cartaUtilizada.Nombre)
            {
                cartasDeLaMano.RemoveAt(cartasDeLaMano.IndexOf(c));
            }
        }*/
        for (int i = cartasDeLaMano.Count - 1; i >= 0; i--)
        {
            if (cartasDeLaMano[i].Nombre == cartaUtilizada.Nombre)
            {
                cartasDeLaMano.RemoveAt(i);
                Destroy(cartaUtilizada.transform.parent.gameObject);
                break;
            }

        }

        MostrarMano();
    }

    int positivo = 0;
    int negativo = 0;
    public void MostrarMano()
    {
        //limpiamos
        foreach (GameObject c in referenciasDeCartas)
        {
            Destroy(c.gameObject);
        }

        int incremento = 20;

        bool esImpar = cartasDeLaMano.Count % 2 != 0;

        int ordeInLayer = 0;

        foreach (Carta c in cartasDeLaMano)
        {
            GameObject objeto = new GameObject(c.name + c.Tipo + c.Puntaje);
            objeto.transform.SetParent(referenciaDePosicionDeCarta.transform);
            objeto.transform.position = referenciaDePosicionDeCarta.transform.position;

            referenciasDeCartas.Add(objeto);
            //Tomar x cartas de la baraja y agregarlas a la mano
            Carta cartaInstanciada = GameObject.Instantiate(c, objeto.transform);//instanciamos la carta
            ordeInLayer++;
            cartaInstanciada.click = click;

            //le damos rotacion
            if (!esImpar)
            {

                if (positivo <= negativo)
                {

                    Vector3 rotacion = objeto.transform.rotation.eulerAngles;
                    rotacion.z = incremento;
                    objeto.transform.eulerAngles = rotacion;
                    positivo++;
                    cartaInstanciada.gameObject.GetComponent<SpriteRenderer>().sortingOrder = incremento * -1;
                }
                else
                {
                    Vector3 rotacion = objeto.transform.rotation.eulerAngles;
                    rotacion.z = incremento * -1;
                    objeto.transform.eulerAngles = rotacion;
                    negativo++;
                    cartaInstanciada.gameObject.GetComponent<SpriteRenderer>().sortingOrder = incremento * -1 * -1;
                    incremento += 50;
                }
            }
            else
            {
                esImpar = !esImpar;
            }
        }

    }

}
