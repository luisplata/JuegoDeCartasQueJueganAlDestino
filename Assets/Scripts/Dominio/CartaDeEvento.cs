using UnityEngine;
using TMPro;

public class CartaDeEvento : CartaGenerica
{
    public ClickDeCartaEvento click;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.OnClick(this);
        }
    }
    public string textoParaCarta;

    public override void CambiarElTextoDentroDeLaCarta()
    {    
        gameObject.transform.Find("Canvas").Find("Panel").Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = textoParaCarta;   
    }
}
