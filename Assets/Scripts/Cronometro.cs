using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public float tiempoTotalExposicion = 0f;
    public float tiempoNivel = 0f;

    public bool simulacionActiva = false;
    public bool nivelActivo = false;


    void Start()
    {
        ReanudarSimulacion();
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

    // Inicia un nivel
    public void IniciarNivel()
    {
        nivelActivo = true;
        simulacionActiva = true;
        tiempoNivel = 0f;
    }

    // Pausa por menú o escape
    public void PausarSimulacion()
    {
        simulacionActiva = false;
        nivelActivo = false;
    }

    // Continuar después de pausa
    public void ReanudarSimulacion()
    {
        simulacionActiva = true;
        nivelActivo = true;
    }

    // Cuando termina el nivel
    public void FinalizarNivel()
    {
        nivelActivo = false;
        simulacionActiva = false;

        Debug.Log("Tiempo nivel: " + tiempoNivel.ToString("F2"));
        Debug.Log("Tiempo total exposición: " + tiempoTotalExposicion.ToString("F2"));
    }
}