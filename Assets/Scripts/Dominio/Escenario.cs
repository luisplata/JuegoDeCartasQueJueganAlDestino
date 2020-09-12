using System;
using System.Collections;
using System.Collections.Generic;
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

    public void UltimoActo()
    {
        playableDirector.playableAsset = Instantiate(PlayableSalida);
        playableDirector.Play();
        StartCoroutine(PuedeContinuarConLaEjecucion());
    }

    IEnumerator PuedeContinuarConLaEjecucion()
    {
        Debug.Log("Antes");
        yield return new WaitForSeconds((float)playableDirector.duration);
        Debug.Log("Despues");
    }

    private void Update()
    {
        FinalizoLaAnimacion = (playableDirector.duration - playableDirector.time) < 0.01f;
    }

    public bool FinalizoLaAnimacion { get; private set; }
}
