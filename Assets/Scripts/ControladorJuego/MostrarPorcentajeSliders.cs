using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MostrarPorcentajeSliders : MonoBehaviour
{
    public TextMeshProUGUI porcentajeDelTexto;
    // Start is called before the first frame update
    void Start()
    {
        porcentajeDelTexto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void ActualizarTexto(float value)
    {
        porcentajeDelTexto.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
