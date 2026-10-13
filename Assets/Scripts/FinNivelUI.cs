using UnityEngine;
using TMPro;
using System.Collections;

public class FinNivelUI : MonoBehaviour
{
    public GameObject panelFinNivel;

    public TextMeshProUGUI textoTiempoNivel;
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoEscNivel;

    public float tiempoMostrar = 5f;

    public void MostrarPanel()
    {
        // Mostrar los datos del nivel
        textoTiempoNivel.text =
            "Tiempo del nivel: " +
            FormatearTiempo(GameManager.instancia.cronometro.tiempoNivel);

        textoTiempoTotal.text =
            "Tiempo total: " +
            FormatearTiempo(GameManager.instancia.cronometro.tiempoTotalExposicion);

        textoEscNivel.text =
            "Veces que escapó: " +
            GameManager.instancia.vecesEscNivel;

        // Mostrar panel
        panelFinNivel.SetActive(true);

        // Iniciar cuenta regresiva
        StartCoroutine(EsperarYVolverAlHub());
    }

    private IEnumerator EsperarYVolverAlHub() // Coroutine para esperar un tiempo y luego volver al hub
    {
        yield return new WaitForSecondsRealtime(tiempoMostrar); // Esperar tiempoMostrar segundos en tiempo real (ignora el Time.timeScale)

        panelFinNivel.SetActive(false);

        GameManager.instancia.VolverAlHub(); // Llamar al método para volver al hub
    }

    private string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f); // Obtener los minutos
        int segundos = Mathf.FloorToInt(tiempo % 60f); // Obtener los segundos restantes

        return minutos.ToString("00") + ":" + segundos.ToString("00"); // Formatear como MM:SS
    }
}