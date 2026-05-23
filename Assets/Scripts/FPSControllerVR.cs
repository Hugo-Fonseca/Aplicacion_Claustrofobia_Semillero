using UnityEngine;
using UnityEngine.InputSystem;

public class FPSControllerVR : MonoBehaviour
{
    public float velocidad = 2.5f;

    private CharacterController controller;

    private float velocidadOriginal;

    private Vector2 movimientoInput;

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
        Vector3 mover =
            transform.right * movimientoInput.x +
            transform.forward * movimientoInput.y;

        controller.Move(mover * velocidad * Time.deltaTime);
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
