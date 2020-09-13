using UnityEngine;

public class ControladorDeAnimaciones : MonoBehaviour
{
    [SerializeField] private Animator obeja;
    private void Start()
    {
        obeja = GameObject.Find("cuerpo").GetComponent<Animator>();
        obeja.SetBool("Saltando",true);
    }
}