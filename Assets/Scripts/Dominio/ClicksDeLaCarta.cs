using UnityEngine;
using System.Collections;
using TMPro;

namespace Assets.Scripts.Integracion
{

    public class ClicksDeLaCarta : MonoBehaviour
    {
        [SerializeField] private CartasEnLaMano cartasEnLaMano;
        public void OnClick(Carta carta)
        {
            cartasEnLaMano.UsarCarta(carta);
            //manejadorDeEventos.SiguienteEscena(carta);//Este va para las cartas de evento
        }
    }
}
