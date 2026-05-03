using UnityEngine;
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

        switch (GameManager.instancia.nivelActual)
        {
            case 1:
                GameManager.instancia.incNivel1 = valor;
                break;

            case 2:
                GameManager.instancia.incNivel2 = valor;
                break;

            case 3:
                GameManager.instancia.incNivel3 = valor;
                break;

            case 4:
                GameManager.instancia.incNivel4 = valor;
                break;
        }

        Debug.Log("Nivel de incomodidad: " + incomodidad);
    }

    public void VolverAlHub()
    {
        // Reiniciar pausas del nivel actual
        GameManager.instancia.vecesEscNivel = 0;

        // Ocultar panel
        panelFinNivel.SetActive(false);

        // Volver al Hub
        GameManager.instancia.VolverAlHub();
    }
}