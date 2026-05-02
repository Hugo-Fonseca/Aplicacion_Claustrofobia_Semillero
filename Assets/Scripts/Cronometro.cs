using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public float tiempoTotalExposicion = 0f;
    public float tiempoNivel = 0f;

    public bool simulacionActiva = false;
    public bool nivelActivo = false;

    void Start()
    {
        // No iniciar en el Hub
        simulacionActiva = false;
        nivelActivo = false;
    }

    void Update()
    {
        if (simulacionActiva)
        {
            tiempoTotalExposicion += Time.deltaTime;
        }

        if (nivelActivo)
        {
            tiempoNivel += Time.deltaTime;
        }
    }

    // Iniciar nivel
    public void IniciarNivel()
    {
        tiempoNivel = 0f;
        simulacionActiva = true;
        nivelActivo = true;
    }

    // Pausar simulación
    public void PausarSimulacion()
    {
        simulacionActiva = false;
        nivelActivo = false;
    }

    // Reanudar simulación
    public void ReanudarSimulacion()
    {
        simulacionActiva = true;
        nivelActivo = true;
    }

    // Finalizar nivel
    public void FinalizarNivel()
    {
        simulacionActiva = false;
        nivelActivo = false;

        Debug.Log("Tiempo nivel: " + tiempoNivel.ToString("F2"));
        Debug.Log("Tiempo total exposición: " + tiempoTotalExposicion.ToString("F2"));
    }

    // Reiniciar para nuevo nivel
    public void ReiniciarCronometro()
    {
        tiempoNivel = 0f;
        simulacionActiva = false;
        nivelActivo = false;
    }
}