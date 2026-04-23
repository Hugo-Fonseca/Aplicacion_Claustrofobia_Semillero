using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float velocidad = 2.5f;
    public float sensibilidadMouse = 120f;

    public Transform camara; // Referencia directa a la cámara

    private CharacterController controller;
    private float rotacionVertical = 0f;

    private float velocidadOriginal;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        velocidadOriginal = velocidad;
    }

    void Update()
    {
        // Si el cursor está libre (menú de pausa), no permitir movimiento ni cámara
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        Movimiento();
        Mirar();
    }

    void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        controller.Move(mover * velocidad * Time.deltaTime);
    }

    void Mirar()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -80f, 80f);

        camara.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidad = nuevaVelocidad;
    }

    public void RestaurarVelocidad()
    {
        velocidad = velocidadOriginal;
    }
}