using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinNivelUI : MonoBehaviour
{
    public GameObject panelFinNivel;

    public TextMeshProUGUI textoTiempoNivel;
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoEscNivel;

    private int incomodidad = 0;

    public void MostrarPanel()
    {
        panelFinNivel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        textoTiempoNivel.text =
            "Tiempo del nivel: " +
            GameManager.instancia.cronometro.tiempoNivel.ToString("F1") + " s";

        textoTiempoTotal.text =
            "Tiempo total: " +
            GameManager.instancia.cronometro.tiempoTotalExposicion.ToString("F1") + " s";

        textoEscNivel.text =
            "Veces que pausó (ESC): " +
            GameManager.instancia.vecesEscNivel;
    }

    public void SeleccionarIncomodidad(int valor)
    {
        incomodidad = valor;

        int escena = SceneManager.GetActiveScene().buildIndex;

        if (escena == 1) GameManager.instancia.incNivel1 = valor;
        if (escena == 2) GameManager.instancia.incNivel2 = valor;
        if (escena == 3) GameManager.instancia.incNivel3 = valor;
        if (escena == 4) GameManager.instancia.incNivel4 = valor;
    }

    public void SiguienteNivel()
    {
        // Reiniciar datos del nivel
        GameManager.instancia.vecesEscNivel = 0;
        GameManager.instancia.cronometro.tiempoNivel = 0f;

        // Obtener escena actual
        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        // Cargar siguiente escena
        SceneManager.LoadScene(escenaActual + 1);
    }
}