using UnityEngine;
using System.Collections;
using TMPro;

namespace Assets.Scripts.Integracion
{

    public class ClicksDeLaCarta : Click
    {
        [SerializeField] private TextMeshProUGUI texto;
        [SerializeField] private CartasEnLaMano cartasEnLaMano;
        public override void OnClick(Carta carta)
        {
            Debug.Log(">>>>>Se hizo click en la carta " + carta.name + carta.Tipo + carta.Puntaje);
            texto.text = "La Carta tiene este tipo " + carta.Tipo + " y valor de " + carta.Puntaje;
            cartasEnLaMano.UsarCarta(carta);
        }
    }
}
