using UnityEngine;

public class GestorIdioma : MonoBehaviour
{
    private int idiomaActual;

    void Start()
    {
        CargarPreferenciasJugador();
        AplicarIdioma();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CambiarIdioma();
        }
    }

    void CargarPreferenciasJugador()
    {
        if (PlayerPrefs.HasKey("idioma"))
        {
            idiomaActual = PlayerPrefs.GetInt("idioma");
        }
        else
        {
            idiomaActual = 0;
            PlayerPrefs.SetInt("idioma", idiomaActual);
        }
    }

    void CambiarIdioma()
    {
        idiomaActual = 1 - idiomaActual; // Alternar entre 0 y 1
        PlayerPrefs.SetInt("idioma", idiomaActual);
        AplicarIdioma();
    }

    void AplicarIdioma()
    {
        if (GestorLocalizacion.instancia != null)
        {
            string idioma = idiomaActual == 0 ? "es" : "en";
            GestorLocalizacion.instancia.CargarTextoLocalizado(idioma);
            ActualizarTodosLosTextos();
        }
        else
        {
            Debug.LogError("GestorLocalizacion instancia no está inicializada.");
        }
    }

    void ActualizarTodosLosTextos()
    {
        foreach (TextoLocalizado texto in FindObjectsOfType<TextoLocalizado>())
        {
            texto.ActualizarTexto();
        }
    }
}
