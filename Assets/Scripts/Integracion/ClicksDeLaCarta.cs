using UnityEngine;
using System.Collections;
using TMPro;

namespace Assets.Scripts.Integracion
{

    public class ClicksDeLaCarta : Click
    {
        [SerializeField] private TextMeshProUGUI texto;
        [SerializeField] private CartasEnLaMano cartasEnLaMano;
        [SerializeField] private ManejadorDeEventos manejadorDeEventos;
        public override void OnClick(Carta carta)
        {

            manejadorDeEventos.SiguienteEscena(carta);
            cartasEnLaMano.UsarCarta(carta);
        }
    }
}
