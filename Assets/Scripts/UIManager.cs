using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoTiempoNivel;

    public GameObject panelTiempo;

    void Update()
    {
        if (GameManager.instancia != null && GameManager.instancia.cronometro != null)
        {
            textoTiempoTotal.text =
                "Tiempo Total: " +
                GameManager.instancia.cronometro.tiempoTotalExposicion.ToString("F1");

            textoTiempoNivel.text =
                "Tiempo Nivel: " +
                GameManager.instancia.cronometro.tiempoNivel.ToString("F1");
        }
    }

    public void MostrarTiempo()
    {
        panelTiempo.SetActive(true);
    }

    public void OcultarTiempo()
    {
        panelTiempo.SetActive(false);
    }
}