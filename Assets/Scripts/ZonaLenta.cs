using UnityEngine;

public class ZonaLenta : MonoBehaviour
{
    public float velocidadReducida = 1.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController jugador = other.GetComponent<FPSController>();

            if (jugador != null)
            {
                jugador.CambiarVelocidad(velocidadReducida);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController jugador = other.GetComponent<FPSController>();

            if (jugador != null)
            {
                jugador.RestaurarVelocidad();
            }
        }
    }
}