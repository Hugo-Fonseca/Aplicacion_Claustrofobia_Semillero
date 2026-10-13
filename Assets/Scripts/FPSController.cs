
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float velocidad = 2.5f;
    public float sensibilidadMouse = 120f;

    public Transform camara;

    private CharacterController controller;
    private float rotacionVertical = 0f;
    private float velocidadOriginal;
    private AudioSource audioPasos;

    [Header("Sonido de pasos")]
    public float pitchNormal = 1f;
    public float pitchLento = 0.7f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioPasos = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        velocidadOriginal = velocidad;

        if (audioPasos != null)
        {
            audioPasos.pitch = pitchNormal;
        }
    }

    void Update()
    {
        // Si el cursor está libre, no permitir movimiento ni cámara.
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

        bool moviendose = mover.magnitude > 0.1f;

        if (audioPasos != null)
        {
            if (moviendose)
            {
                if (!audioPasos.isPlaying)
                {
                    audioPasos.Play();
                }
            }
            else
            {
                if (audioPasos.isPlaying)
                {
                    audioPasos.Pause();
                }
            }
        }
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

        if (audioPasos != null)
        {
            audioPasos.pitch = pitchLento;
        }
    }

    public void RestaurarVelocidad()
    {
        velocidad = velocidadOriginal;

        if (audioPasos != null)
        {
            audioPasos.pitch = pitchNormal;
        }
    }
}
