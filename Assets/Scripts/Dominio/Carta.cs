using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] private TiposElegibles tipo;
    [SerializeField] private TipoDeCarta tipoDeCarta;
    [SerializeField] private int puntaje;
    [SerializeField] private string nombre;

    public Click click;

    public int Puntaje => puntaje;
    public TiposElegibles Tipo => tipo;
    public TipoDeCarta TipoDeCarta => tipoDeCarta;
    public string Nombre => nombre;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.OnClick(this);
        }
    }
}