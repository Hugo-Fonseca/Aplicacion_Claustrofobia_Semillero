using UnityEngine;
using System.IO;

public class GuardarDatos : MonoBehaviour
{
    private string rutaArchivo;

    void Start()
    {
        rutaArchivo = Application.persistentDataPath + "/resultados_simulacion.csv";

        if (!File.Exists(rutaArchivo))
        {
            string encabezado =
                "TiempoTotal;" +
                "T_Contenedores;" +
                "T_Pasillo;" +
                "T_Ascensor;" +
                "T_Cueva;" +
                "ESC_Contenedores;" +
                "ESC_Pasillo;" +
                "ESC_Ascensor;" +
                "ESC_Cueva;" +
                "Inc_Contenedores;" +
                "Inc_Pasillo;" +
                "Inc_Ascensor;" +
                "Inc_Cueva\n";

            File.WriteAllText(rutaArchivo, encabezado);

            Debug.Log("Archivo CSV creado en: " + rutaArchivo);
        }
    }

    public void Guardar()
    {
        if (GameManager.instancia == null)
        {
            Debug.LogError("GameManager no encontrado");
            return;
        }

        string linea =
            GameManager.instancia.cronometro.tiempoTotalExposicion.ToString("F2") + ";" +
            GameManager.instancia.tiempoNivel1.ToString("F2") + ";" +
            GameManager.instancia.tiempoNivel2.ToString("F2") + ";" +
            GameManager.instancia.tiempoNivel3.ToString("F2") + ";" +
            GameManager.instancia.tiempoNivel4.ToString("F2") + ";" +
            GameManager.instancia.escNivel1 + ";" +
            GameManager.instancia.escNivel2 + ";" +
            GameManager.instancia.escNivel3 + ";" +
            GameManager.instancia.escNivel4 + ";" +
            GameManager.instancia.incNivel1 + ";" +
            GameManager.instancia.incNivel2 + ";" +
            GameManager.instancia.incNivel3 + ";" +
            GameManager.instancia.incNivel4 + "\n";

        File.AppendAllText(rutaArchivo, linea);

        Debug.Log("Datos guardados en: " + rutaArchivo);
    }
}