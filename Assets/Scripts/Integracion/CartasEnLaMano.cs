using Assets.Scripts.Integracion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartasEnLaMano : MonoBehaviour
{
    public List<Carta> cartasDeLaMano;
    public List<CartaDeEvento> cartasDeEventoEnLaMano;
    [SerializeField] private Baraja baraja;
    [SerializeField] private BarajaDeEventos barajaDeEventos;
    public GameObject referenciaDePosicionDeCarta, referenciaDePosicionDeCartaEvento;
    public List<GameObject> referenciasDeCartas, referenciaDeCartaEvento;
    [SerializeField] private ClicksDeLaCarta click;
    [SerializeField] private ClickDeCartaEvento clickEvento;
    [SerializeField] private ManejadorDeEventos manejadorDeEventos;
    [SerializeField] private bool TodasLascartasEnlaMano = false;
    [SerializeField] public int cantidadDeCartasMaxima;
    

    public void TomarCartas()
    {
        bool sePuedeTomarMasCartas = cartasDeLaMano.Count < cantidadDeCartasMaxima;

        if (sePuedeTomarMasCartas)
        {
            Carta carta = baraja.TomarCarta();
            carta.click = click;
            cartasDeLaMano.Add(carta);
            MostrarMano();
        }
    }

    public void UsarCarta(Carta cartaUtilizada)
    {
        for (int i = cartasDeLaMano.Count - 1; i >= 0; i--)
        {
            bool esLaMismaCarta = cartasDeLaMano[i].Nombre == cartaUtilizada.Nombre;
            if (esLaMismaCarta)
            {
                cartasDeLaMano.RemoveAt(i);
                Destroy(cartaUtilizada.transform.parent.gameObject);
                break;
            }

        }
        MostrarMano();
        OcultamosMano();
        //mostramos las alternativas de cartas de evento
        MostrarAlternativasDeCartasdeEvento(cartaUtilizada);
    }

    public void OcultamosMano()
    {
        foreach (GameObject c in referenciasDeCartas)
        {
            c.gameObject.SetActive(false);
        }
    }
    public void MostramosMano()
    {
        foreach (Carta c in cartasDeLaMano)
        {
            c.gameObject.gameObject.SetActive(true);
        }
    }

    private void MostrarAlternativasDeCartasdeEvento(Carta cartaUtilizada)
    {
        //por ahora no va a importar cuales carta de evento saque, solo va a sacar 3
        foreach (GameObject c in referenciaDeCartaEvento)
        {
            Destroy(c.gameObject);
        }

        int incremento = 35;
        //Debemos tomar todas las cartas que podamos
        cartasDeEventoEnLaMano = new List<CartaDeEvento>();


        referenciaDeCartaEvento = new List<GameObject>();

        bool esImpar = manejadorDeEventos.eventoActual.eventosSiguientes.Count % 2 != 0;
        foreach (Evento evento in manejadorDeEventos.eventoActual.eventosSiguientes)
        {
            CartaDeEvento cartaDelEvento = barajaDeEventos.TomarCarta();
            GameObject objeto = new GameObject(cartaDelEvento.Nombre + cartaDelEvento.Tipo + cartaDelEvento.Puntaje);
            objeto.transform.SetParent(referenciaDePosicionDeCartaEvento.transform);
            objeto.transform.position = referenciaDePosicionDeCartaEvento.transform.position;
            referenciaDeCartaEvento.Add(objeto);
            //Tomar x cartas de la baraja y agregarlas a la mano
            CartaDeEvento cartaInstanciada = GameObject.Instantiate(cartaDelEvento, objeto.transform);//instanciamos la carta
            cartaInstanciada.click = clickEvento;
            cartaDelEvento.textoParaCarta = evento.gameObject.name;
            cartaInstanciada.CambiarElTextoDentroDeLaCarta();
            cartasDeEventoEnLaMano.Add(cartaDelEvento);

            //le damos rotacion
            if (!esImpar)
            {
                if (positivo <= negativo)
                {
                    int incrementoPorCoso = incremento * -1;
                    Vector3 rotacion = objeto.transform.rotation.eulerAngles;
                    rotacion.z = incremento;
                    objeto.transform.eulerAngles = rotacion;
                    positivo++;
                    cartaInstanciada.gameObject.GetComponent<SpriteRenderer>().sortingOrder = incrementoPorCoso;
                    cartaInstanciada.gameObject.transform.Find("Canvas").GetComponent<Canvas>().sortingOrder = incrementoPorCoso + 1;
                }
                else
                {
                    Vector3 rotacion = objeto.transform.rotation.eulerAngles;
                    int incrementoPorCoso = incremento * -1 * -1;
                    rotacion.z = incremento * -1;
                    objeto.transform.eulerAngles = rotacion;
                    negativo++;
                    cartaInstanciada.gameObject.GetComponent<SpriteRenderer>().sortingOrder = incrementoPorCoso;
                    cartaInstanciada.gameObject.transform.Find("Canvas").GetComponent<Canvas>().sortingOrder = incrementoPorCoso + 1;
                    incremento += 40;
                }
            }
            else
            {
                esImpar = !esImpar;
            }


            if (!esImpar)
            {
                if (positivo <= negativo)
                {

                }
                else
                {
                }
            }
            else
            {
                esImpar = !esImpar;
            }
        }

        foreach (GameObject c in referenciaDeCartaEvento)
        {
            
        }
        incremento = 35;
        positivo = 0;
        negativo = 0;
        esImpar = cartasDeEventoEnLaMano.Count % 2 != 0;
        foreach (CartaDeEvento evento in cartasDeEventoEnLaMano)
        {
            Debug.Log(evento.gameObject.name);
            //le damos rotacion
            
        }

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

        int incremento = 35;

        bool esImpar = cartasDeLaMano.Count % 2 != 0;
        referenciasDeCartas = new List<GameObject>();
        foreach (Carta c in cartasDeLaMano)
        {
            GameObject objeto = new GameObject(c.name + c.Tipo + c.Puntaje);
            objeto.transform.SetParent(referenciaDePosicionDeCarta.transform);
            objeto.transform.position = referenciaDePosicionDeCarta.transform.position;

            referenciasDeCartas.Add(objeto);
            //Tomar x cartas de la baraja y agregarlas a la mano
            Carta cartaInstanciada = GameObject.Instantiate(c, objeto.transform);//instanciamos la carta
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
                    incremento += 40;
                }
            }
            else
            {
                esImpar = !esImpar;
            }
        }

    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        TomarCartas();
    }

}
