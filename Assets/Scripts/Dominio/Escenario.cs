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
    }

    public bool FinalizoLaAnimacion { get; private set; }
}
