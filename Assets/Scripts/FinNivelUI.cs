using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinNivelUI : MonoBehaviour
{
    public GameObject panelFinNivel;

    public TextMeshProUGUI textoTiempoNivel;
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoEscNivel;

    // TODOS los botones de incomodidad
    public Button[] botonesIncomodidad;

    public Color colorSeleccionado = Color.green;
    private Color[] coloresOriginales;

    private bool yaSelecciono = false;
    private int incomodidad = 0;

    void Start()
    {
        coloresOriginales = new Color[botonesIncomodidad.Length];

        for (int i = 0; i < botonesIncomodidad.Length; i++)
        {
            coloresOriginales[i] =
                botonesIncomodidad[i].GetComponent<Image>().color;
        }
    }

    public void MostrarPanel()
    {
        panelFinNivel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Reiniciar selección cada vez que abre el panel
        yaSelecciono = false;

        // Reactivar botones
        foreach (Button boton in botonesIncomodidad)
        {
            boton.interactable = true;
        }

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
        if (yaSelecciono)
            return;

        yaSelecciono = true;
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

        // Resaltar botón seleccionado
        for (int i = 0; i < botonesIncomodidad.Length; i++)
        {
            Button boton = botonesIncomodidad[i];

            if (i == valor - 1)
            {
                boton.GetComponent<Image>().color = colorSeleccionado;
            }
            else
            {
                boton.interactable = false;
            }
        }

        Debug.Log("Nivel de incomodidad: " + incomodidad);
    }

    public void VolverAlHub()
    {
        GameManager.instancia.vecesEscNivel = 0;

        panelFinNivel.SetActive(false);

        GameManager.instancia.VolverAlHub();
    }
}