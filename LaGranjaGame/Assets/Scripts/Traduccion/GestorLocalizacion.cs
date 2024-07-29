using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GestorLocalizacion : MonoBehaviour
{
    public static GestorLocalizacion instancia;
    private Dictionary<string, string> textoLocalizado;
    private string textoNoEncontrado = "Texto no encontrado";

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public void CargarTextoLocalizado(string idioma)
    {
        textoLocalizado = new Dictionary<string, string>();
        string rutaArchivo = Path.Combine(Application.streamingAssetsPath, idioma + ".json");

        if (File.Exists(rutaArchivo))
        {
            string datosJson = File.ReadAllText(rutaArchivo);
            DatosLocalizacion datosCargados = JsonUtility.FromJson<DatosLocalizacion>(datosJson);

            foreach (var item in datosCargados.items)
            {
                textoLocalizado.Add(item.clave, item.valor);
            }
        }
    }

    public string ObtenerValorLocalizado(string clave)
    {
        string resultado = textoNoEncontrado;
        if (textoLocalizado != null && textoLocalizado.ContainsKey(clave))
        {
            resultado = textoLocalizado[clave];
        }
        return resultado;
    }
}

[System.Serializable]
public class DatosLocalizacion
{
    public ElementoLocalizacion[] items;
}

[System.Serializable]
public class ElementoLocalizacion
{
    public string clave;
    public string valor;
}
