using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoTiempoNivel;

    public GameObject panelTiempo;

    void Update()
    {
        if (!panelTiempo.activeSelf) return;

        if (GameManager.instancia == null || GameManager.instancia.cronometro == null)
            return;

        if (textoTiempoTotal != null)
        {
            textoTiempoTotal.text =
                "Tiempo Total: " +
                FormatearTiempo(GameManager.instancia.cronometro.tiempoTotalExposicion);
        }

        if (textoTiempoNivel != null)
        {
            textoTiempoNivel.text =
                "Tiempo Nivel: " +
                FormatearTiempo(GameManager.instancia.cronometro.tiempoNivel);
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

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}