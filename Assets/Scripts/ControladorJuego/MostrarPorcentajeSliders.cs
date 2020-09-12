using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPorcentajeSliders : MonoBehaviour
{
    Text porcentajeDelTexto;
    // Start is called before the first frame update
    void Start()
    {
        porcentajeDelTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    public void ActualizarTexto(float value)
    {
        porcentajeDelTexto.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
