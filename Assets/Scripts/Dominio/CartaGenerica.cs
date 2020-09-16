using TMPro;
using UnityEngine;

public abstract class CartaGenerica : MonoBehaviour
{
    [SerializeField] protected TiposElegibles tipo;
    [SerializeField] protected string nombre;
    [SerializeField] protected int puntaje;
    public abstract void CambiarElTextoDentroDeLaCarta();
    public TiposElegibles Tipo => tipo;
    public string Nombre => nombre;
    public int Puntaje => puntaje;
}