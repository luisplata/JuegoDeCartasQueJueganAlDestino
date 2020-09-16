using Assets.Scripts.Integracion;
using UnityEngine;

public class Carta : CartaGenerica
{
    [SerializeField] private TipoDeCarta tipoDeCarta;
    public ClicksDeLaCarta click;


    public TipoDeCarta TipoDeCarta => tipoDeCarta;

    public override void CambiarElTextoDentroDeLaCarta()
    {
        throw new System.NotImplementedException();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.OnClick(this);
        }
    }
}
