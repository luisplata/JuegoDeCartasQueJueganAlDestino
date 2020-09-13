using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

public class Escenario : MonoBehaviour
{
    [SerializeField] PlayableAsset PlayableEsntrada, PlayableSalida;
    [SerializeField] private PlayableDirector playableDirector;

    public void PrimerActo()
    {
        playableDirector.playableAsset = Instantiate(PlayableEsntrada);
        playableDirector.Play();
    }

    public async Task UltimoActo()
    {
        playableDirector.playableAsset = Instantiate(PlayableSalida);
        playableDirector.Play();
        await PuedeContinuarConLaEjecucion();
    }

    private async Task PuedeContinuarConLaEjecucion()
    {
        Debug.Log("Antes");
        await Task.Delay(TimeSpan.FromSeconds(playableDirector.duration));
        Debug.Log("Despues");
    }

    private void Update()
    {
        FinalizoLaAnimacion = (playableDirector.duration - playableDirector.time) < 0.01f;
        //vamos a verificar si tenemos que mostrar si o no el desafio, justo despues de la animacion de entrada
        if (FinalizoLaAnimacion && volverAmirar)
        {
            MostramosElDesafioAlJugador();
        }
    }

    private void MostramosElDesafioAlJugador()
    {

        volverAmirar = false;
    }
    private bool volverAmirar = true;
    public bool FinalizoLaAnimacion { get; private set; }
}
