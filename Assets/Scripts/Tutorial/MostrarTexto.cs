
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;


public class MostrarTexto : MonoBehaviour
{
    [SerializeField] private Text textoTutorial;
    [SerializeField] private Image panelFondoTutorial;
    int numeroDeTextos = 1;
    CartasEnLaMano cartasEnLaMano;
    [SerializeField] bool textoAparecido = false;

    // Start is called before the first frame update
    void Start()
    {
        textoTutorial = GameObject.Find("Text").GetComponent<Text>();
        panelFondoTutorial = GameObject.Find("Panel").GetComponent<Image>();
        cartasEnLaMano = GameObject.Find("LaManoCartasEnLaMano").GetComponent<CartasEnLaMano>();

        autoTexto();
    }

    private void Update()
    {
        Debug.Log(cartasEnLaMano.cartasDeLaMano.Count + " CARTAS EN LA MANO");
        ValorarCartaEnLaMano();
    }
    async void autoTexto()
    {

        if (textoAparecido == false)
        {
            await EsperarQueAcabeLaEscena();

            textoTutorial.text = "Vaya... Te encuentras dentro de una habitación desconocida, ¿cómo vas a salir de ahí?. ¡PUF! Acaba de aparecer un mazo mágico, ¿que harás con él?";
            await TiempoEntreTextoYTexto();

            textoTutorial.text = "Para poder salir de la habitación deberás darle click a tu mazo mágico para obtener una carta y así poder salir de esta habitación del infierno.";
            textoAparecido = true;

        }
    }

    public void ValorarCartaEnLaMano()
    {
        if (cartasEnLaMano.cartasDeLaMano.Count == 1)
        {
            Debug.Log("EVALUO EL CLICKKKKKKKKKK DE TENER LA CARTA");
            textoTutorial.text = "Perfecto ya tienes la carta en la mano, Ahora deberías utilizarla para poder abrir esa puerta que tienes enfrente.";
        }
    }

    private async Task EsperarQueAcabeLaEscena()
    {

        await Task.Delay(TimeSpan.FromSeconds(5f));

    }
    private async Task TiempoEntreTextoYTexto()
    {

        await Task.Delay(TimeSpan.FromSeconds(5f));

    }

}

