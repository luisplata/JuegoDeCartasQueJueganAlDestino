
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class MostrarTexto : MonoBehaviour
{
    [SerializeField] private Text textoTutorial;
    [SerializeField] private Image panelFondoTutorial;
    [SerializeField] private List<string> dialogos;
    [SerializeField] private string dialogoDeLaCartaDeLaMana;
    int numeroDeTextos = 1;
    [SerializeField] private CartasEnLaMano cartasEnLaMano;
    [SerializeField] bool textoAparecido = false;

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
            textoAparecido = true;
        }
    }

    public void ValorarCartaEnLaMano()
    {
        if (cartasEnLaMano.cartasDeLaMano.Count == 1)
        {
            Debug.Log("EVALUO EL CLICKKKKKKKKKK DE TENER LA CARTA");
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

