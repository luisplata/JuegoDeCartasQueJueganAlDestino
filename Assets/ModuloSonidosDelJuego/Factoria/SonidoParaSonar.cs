using UnityEngine;
public class SonidoParaSonar : MonoBehaviour
{
    [SerializeField] protected Object sonido;
    [SerializeField] protected EnumSonidosParaSonar id;

    public EnumSonidosParaSonar Id => id;
    public Object Sonido => sonido;
}