using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadCorrer = 10f;
    public Transform camaraTransform;

    private float velocidadActual;

    void Start()
    {
        velocidadActual = velocidadMovimiento;
    }

    void Update()
    {
        MoverJugador();
        RotarJugadorConCamara();
    }

    private void MoverJugador()
    {
        // Comprobar si se está presionando la tecla Shift para correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual = velocidadCorrer;
        }
        else
        {
            velocidadActual = velocidadMovimiento;
        }

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        if (movimiento.magnitude >= 0.1f)
        {
            // Calcular la dirección en la que el jugador debe moverse basada en la cámara
            float anguloObjetivo = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + camaraTransform.eulerAngles.y;
            Vector3 direccionMovimiento = Quaternion.Euler(0, anguloObjetivo, 0) * Vector3.forward;

            transform.Translate(direccionMovimiento * velocidadActual * Time.deltaTime, Space.World);
        }
    }

    private void RotarJugadorConCamara()
    {
        Vector3 rotacionCamara = camaraTransform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotacionCamara.y, 0);
    }
}
