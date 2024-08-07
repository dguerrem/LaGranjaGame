using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform objetivo; // El jugador
    public Vector3 offset; // Desplazamiento de la cámara
    public float sensibilidadMouse = 100f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
        Cursor.SetCursor(null, new Vector2(Screen.width / 2, Screen.height / 2), CursorMode.Auto); // Centramos el cursor
        offset = transform.position - objetivo.position; // Calcular el desplazamiento inicial
    }

    void LateUpdate()
    {
        // Rotar la cámara con el ratón
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        rotacionY -= Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        rotacionY = Mathf.Clamp(rotacionY, -35f, 60f); // Limitar la rotación vertical

        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0);
        transform.position = objetivo.position + rotacion * offset;
        transform.LookAt(objetivo);
    }
}
