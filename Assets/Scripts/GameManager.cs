using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public Cronometro cronometro;

    // Nivel actual seleccionado
    public int nivelActual = 0;

    // Veces que el usuario abandona una simulación
    public int vecesAbandono = 0;

    // Total de veces que se seleccionó cualquier nivel
    public int vecesEscNivel = 0;

    // Veces que se escogió cada nivel
    public int escNivel1 = 0;
    public int escNivel2 = 0;
    public int escNivel3 = 0;
    public int escNivel4 = 0;

    // Veces que aumentó la intensidad de cada nivel
    public int incNivel1 = 0;
    public int incNivel2 = 0;
    public int incNivel3 = 0;
    public int incNivel4 = 0;

    // Tiempo acumulado por nivel
    public float tiempoNivel1 = 0f;
    public float tiempoNivel2 = 0f;
    public float tiempoNivel3 = 0f;
    public float tiempoNivel4 = 0f;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Se llama cuando el usuario entra al portal de un nivel
    public void SeleccionarNivel(int nivel)
    {
        nivelActual = nivel;

        // Reiniciar contador de pausas para este nivel
        vecesEscNivel = 0;

        // Registrar qué nivel escogió
        switch (nivel)
        {
            case 1:
                escNivel1++;
                break;

            case 2:
                escNivel2++;
                break;

            case 3:
                escNivel3++;
                break;

            case 4:
                escNivel4++;
                break;
        }

        cronometro.ReiniciarCronometro();
        cronometro.IniciarNivel();

        Debug.Log("Nivel seleccionado: " + nivelActual);
    }
    // Guarda el tiempo del nivel actual
    public void GuardarTiempoNivel()
    {
        switch (nivelActual)
        {
            case 1:
                tiempoNivel1 += cronometro.tiempoNivel;
                break;

            case 2:
                tiempoNivel2 += cronometro.tiempoNivel;
                break;

            case 3:
                tiempoNivel3 += cronometro.tiempoNivel;
                break;

            case 4:
                tiempoNivel4 += cronometro.tiempoNivel;
                break;
        }
    }

    // Registrar incremento de dificultad/intensidad
    public void IncrementarNivel()
    {
        switch (nivelActual)
        {
            case 1:
                incNivel1++;
                break;

            case 2:
                incNivel2++;
                break;

            case 3:
                incNivel3++;
                break;

            case 4:
                incNivel4++;
                break;
        }

        Debug.Log("Incremento registrado en nivel: " + nivelActual);
    }

    // Finaliza correctamente un nivel
    public void FinalizarNivel()
    {
        cronometro.FinalizarNivel();

        GuardarTiempoNivel();

        Debug.Log("Nivel finalizado: " + nivelActual);
        Debug.Log("Tiempo del nivel: " + cronometro.tiempoNivel.ToString("F2"));

        VolverAlHub();
    }

    // Si el usuario abandona la simulación
    public void AbandonarSimulacion()
    {
        vecesAbandono++;

        cronometro.PausarSimulacion();

        Debug.Log("Usuario abandonó la simulación");
        Debug.Log("Tiempo total exposición: " + cronometro.tiempoTotalExposicion.ToString("F2"));

        VolverAlHub();
    }

    // Regresa al Hub principal
    public void VolverAlHub()
    {
        SceneManager.LoadScene("HubPrincipal");
    }
}