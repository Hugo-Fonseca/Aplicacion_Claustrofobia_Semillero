using UnityEngine;

public class AscensorNivel : MonoBehaviour
{
    public float tiempoObjetivo = 120f; // 2 minutos
    private float tiempoActual = 0f;

    private bool completado = false;

    public GameObject panelFinal;

    void Start()
    {
        // Asegura que el panel esté oculto al inicio
        panelFinal.SetActive(false);
    }

    void Update()
    {
        if (!completado && GameManager.instancia.cronometro.simulacionActiva)
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= tiempoObjetivo)
            {
                FinalizarNivel();
            }
        }
    }

    void FinalizarNivel()
    {
        completado = true;

        GameManager.instancia.cronometro.FinalizarNivel();

        // Guardar datos del nivel 3 (ascensor)
        GameManager.instancia.tiempoNivel3 = GameManager.instancia.cronometro.tiempoNivel;
        GameManager.instancia.escNivel3 = GameManager.instancia.vecesEscNivel;

        panelFinal.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Ascensor completado");
    }
}