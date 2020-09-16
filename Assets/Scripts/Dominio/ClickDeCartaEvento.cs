using UnityEngine;

public class ClickDeCartaEvento : MonoBehaviour
{
    [SerializeField] private ManejadorDeEventos manejadorDeEventos;

    public void OnClick(CartaDeEvento carta)
    {
        manejadorDeEventos.SiguienteEscena(carta);
    }
}