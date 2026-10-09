
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
    public float pitchNormal = 1f;
    public float pitchLento = 0.7f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocidadOriginal = velocidad;

        if (audioPasos != null)
        {
            audioPasos.pitch = pitchNormal;
        }
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
        Vector3 adelante = camaraVR.forward;
        Vector3 derecha = camaraVR.right;

        adelante.y = 0;
        derecha.y = 0;

        adelante.Normalize();
        derecha.Normalize();

        Vector3 mover =
            derecha * movimientoInput.x +
            adelante * movimientoInput.y;

        controller.Move(mover * velocidad * Time.deltaTime);

        bool moviendose = movimientoInput.magnitude > 0.1f;

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