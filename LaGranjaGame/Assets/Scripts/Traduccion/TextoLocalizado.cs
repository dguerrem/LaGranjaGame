using UnityEngine;
using UnityEngine.UI;

public class TextoLocalizado : MonoBehaviour
{
    public string clave;

    void Start()
    {
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        Text componenteTexto = GetComponent<Text>();
        if (componenteTexto != null)
        {
            componenteTexto.text = GestorLocalizacion.instancia.ObtenerValorLocalizado(clave);
        }
    }
}
