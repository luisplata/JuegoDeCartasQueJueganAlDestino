using UnityEngine;

public class ManejadorDeSonidosConAudioSource : IManejadorDeSonidosDelJuego
{
    [SerializeField] private AudioSource source;
    [SerializeField] SonidosConfiguration configuracionSonido;

    public override void TocarCancion(EnumSonidosParaSonar sonido)
    {
        SonidosFacotry factoriaDeSonidos = new SonidosFacotry(GameObject.Instantiate(configuracionSonido));
        SonidoParaSonar sonidoPorSonar = factoriaDeSonidos.Create(sonido);
        source.PlayOneShot((AudioClip)sonidoPorSonar.Sonido);
    }
}