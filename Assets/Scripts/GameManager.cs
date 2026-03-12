using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public Cronometro cronometro; // referencia al cronómetro

    public int vecesAbandono = 0;

    public int vecesEscNivel = 0;

    public int escNivel1 = 0;
    public int escNivel2 = 0;
    public int escNivel3 = 0;
    public int escNivel4 = 0;

    public int incNivel1 = 0;
    public int incNivel2 = 0;
    public int incNivel3 = 0;
    public int incNivel4 = 0;

    public float tiempoNivel1 = 0;
    public float tiempoNivel2 = 0;
    public float tiempoNivel3 = 0;
    public float tiempoNivel4 = 0;
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

    public void AbandonarSimulacion()
    {
        vecesAbandono++;

        cronometro.PausarSimulacion();

        Debug.Log("El usuario abandonó la simulación");
        Debug.Log("Tiempo total exposición: " + cronometro.tiempoTotalExposicion.ToString("F2"));
    }
}