
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class MostrarTexto : MonoBehaviour
{
    [SerializeField] public Text textoTutorial;
    [SerializeField] public Image panelFondoTutorial;
    [SerializeField] private List<string> dialogos;
    [SerializeField] private string dialogoDeLaCartaDeLaMana;
    int numeroDeTextos = 1;
    [SerializeField] private CartasEnLaMano cartasEnLaMano;
    [SerializeField] bool textoAparecido = false;
    [SerializeField] public SpriteRenderer barajaImage;

    // Start is called before the first frame update
    void Start()
    {
        autoTexto();
    }

    private void Update()
    {
        Debug.Log(cartasEnLaMano.cartasDeLaMano.Count + " CARTAS EN LA MANO");
        ValorarCartaEnLaMano();
    }
    private async void autoTexto()
    {
        if (textoAparecido == false)
        {
            await EsperarQueAcabeLaEscena();
            panelFondoTutorial.gameObject.SetActive(true);
            textoTutorial.gameObject.SetActive(true);
            foreach (string texto in dialogos)
            {
                textoTutorial.text = texto;
                await TiempoEntreTextoYTexto();
            }
            AparecerElMazo();
            textoAparecido = true;
        }
    }

    private void AparecerElMazo()
    {
        barajaImage.enabled = true;
    }

    public void ValorarCartaEnLaMano()
    {
        if (cartasEnLaMano.cartasDeLaMano.Count == 1)
        {
            textoTutorial.text = dialogoDeLaCartaDeLaMana;
        }
    }

    private async Task EsperarQueAcabeLaEscena()
    {

        await Task.Delay(TimeSpan.FromSeconds(5f));

    }
    private async Task TiempoEntreTextoYTexto()
    {

        await Task.Delay(TimeSpan.FromSeconds(10f));

    }

}

