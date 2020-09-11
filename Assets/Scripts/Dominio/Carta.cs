using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] private TiposElegibles tipo;
    [SerializeField] private int puntaje;
    [SerializeField] private string nombre;
    public Click click;
    private void Awake()
    {
        EleccionDelColor();
    }

    public int Puntaje => puntaje;
    public TiposElegibles Tipo => tipo;
    public string Nombre => nombre;

    private void EleccionDelColor()
    {
        if (tipo == TiposElegibles.A)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            return;
        }
        if (tipo == TiposElegibles.B)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            return;
        }
        if (tipo == TiposElegibles.C)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            return;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.OnClick(this);
        }
    }
}
