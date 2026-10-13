using UnityEngine;
using System.IO;

public class GuardarDatos : MonoBehaviour
{
    private string rutaArchivo; // Variable para almacenar la ruta del archivo CSV

    void Start()
    {
        rutaArchivo = Application.persistentDataPath + "/resultados_simulacion.csv"; // Ruta del archivo CSV en la carpeta persistente de la aplicación

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
                "ESC_Cueva\n";

            File.WriteAllText(rutaArchivo, encabezado);

            Debug.Log("Archivo CSV creado en: " + rutaArchivo);
        }
    }

    public void Guardar() // Método para guardar los datos en el archivo CSV
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
            GameManager.instancia.escNivel4 + "\n";

        File.AppendAllText(rutaArchivo, linea); // Agregar la línea de datos al archivo CSV

        Debug.Log("Datos guardados en: " + rutaArchivo); // Confirmación de que los datos se han guardado
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Evitar que el objeto se destruya al cargar una nueva escena
    }
}