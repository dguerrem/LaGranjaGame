using UnityEngine;
using UnityEngine.UI;

public class CicloDiaNoche : MonoBehaviour
{
    private Light luzDireccional;
    private float tiempoTranscurrido;
    private float duracionDiaCompleto = 30f; // Duración de un día completo en segundos (5 minutos)
    private Text textHoraActual;

    private const string HORA_ACTUAL = "HoraActual";

    private void Start()
    {
        luzDireccional = GetComponent<Light>();
        textHoraActual = GameObject.Find(HORA_ACTUAL).GetComponent<Text>();

    }

    private void Update()
    {
        ActualizarCicloDiaNoche();
        MostrarHoraEnConsola();
    }

    private void ActualizarCicloDiaNoche()
    {
        tiempoTranscurrido += Time.deltaTime;
        float porcentajeDia = (tiempoTranscurrido % duracionDiaCompleto) / duracionDiaCompleto;

        // Rotar la luz direccional para simular el sol moviéndose por el cielo
        luzDireccional.transform.localRotation = Quaternion.Euler(new Vector3((porcentajeDia * 360f) - 90f, 170f, 0));

        // Cambiar la intensidad de la luz según el porcentaje del día (opcional)
        if (porcentajeDia <= 0.5f)
        {
            // Día
            luzDireccional.intensity = Mathf.Lerp(0, 1, porcentajeDia * 2);
        }
        else
        {
            // Noche
            luzDireccional.intensity = Mathf.Lerp(1, 0, (porcentajeDia - 0.5f) * 2);
        }
    }

    private void MostrarHoraEnConsola()
    {
        if (textHoraActual != null)
        {
            float horaDelDia = (tiempoTranscurrido % duracionDiaCompleto) / duracionDiaCompleto * 24f;
            int horas = Mathf.FloorToInt(horaDelDia);
            int minutos = Mathf.FloorToInt((horaDelDia - horas) * 60);
            textHoraActual.text = $"{horas:D2}:{minutos:D2}";
        }
    }
}
