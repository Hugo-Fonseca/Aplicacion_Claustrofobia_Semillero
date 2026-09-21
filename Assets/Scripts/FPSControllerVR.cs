using UnityEngine;
using UnityEngine.InputSystem;

public class FPSControllerVR : MonoBehaviour
{
    public float velocidad = 2.5f;

    private CharacterController controller;

    private float velocidadOriginal;

    private Vector2 movimientoInput;

    [Header("Cámara VR")]
    public Transform camaraVR;

    [Header("Sonido de pasos")]
    public AudioSource audioPasos;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        velocidadOriginal = velocidad;
    }

    void Update()
    {
        Movimiento();
    }

    public void OnMove(InputValue value)
    {
        movimientoInput = value.Get<Vector2>();
    }

    void Movimiento()
    {
        // Dirección hacia donde mira la cámara
        Vector3 adelante = camaraVR.forward;

        // Dirección derecha de la cámara
        Vector3 derecha = camaraVR.right;

        // Evitar que mirar hacia arriba/abajo afecte el movimiento
        adelante.y = 0;
        derecha.y = 0;

        adelante.Normalize();
        derecha.Normalize();

        // Movimiento según la dirección de la cabeza
        Vector3 mover =
            derecha * movimientoInput.x +
            adelante * movimientoInput.y;

        controller.Move(mover * velocidad * Time.deltaTime);

        // Detectar movimiento
        bool moviendose = movimientoInput.magnitude > 0.1f;

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

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidad = nuevaVelocidad;
    }

    public void RestaurarVelocidad()
    {
        velocidad = velocidadOriginal;
    }
}