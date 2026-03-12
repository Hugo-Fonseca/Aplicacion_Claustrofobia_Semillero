using UnityEngine;
using System.IO;

public class GuardarDatos : MonoBehaviour
{
    string rutaArchivo;

    void Start()
    {
        rutaArchivo = Application.dataPath + "/resultados_simulacion.csv"; // Crea base de datos

        if (!File.Exists(rutaArchivo))
        {
            string encabezado =
            "TiempoTotal;T_Contenedores;T_Pasillo;T_Ascensor;T_Cueva;ESC_Contenedores;ESC_Pasillo;ESC_Ascensor;ESC_Cueva;Inc_Contenedores;Inc_Pasillo;Inc_Ascensor;Inc_Cueva\n";

            File.WriteAllText(rutaArchivo, encabezado); // Encabezado de cada seccion
        }
    }

    public void Guardar()
    {
        string linea =
            GameManager.instancia.cronometro.tiempoTotalExposicion + ";" +
            GameManager.instancia.tiempoNivel1 + ";" +
            GameManager.instancia.tiempoNivel2 + ";" +
            GameManager.instancia.tiempoNivel3 + ";" +
            GameManager.instancia.tiempoNivel4 + ";" +
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