using UnityEngine;

public class EscapeSalir : MonoBehaviour
{
    public GameObject menuPausa;
    public UIManager uiManager; // Referencia al UIManager para mostrar/ocultar el tiempo

    private bool enPausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!enPausa)
            {
                Pausar();
            }
            else
            {
                Reanudar();
            }
        }
    }

    public void Pausar()
    {
        enPausa = true;

        GameManager.instancia.vecesEscNivel++;

        GameManager.instancia.cronometro.PausarSimulacion();

        uiManager.MostrarTiempo();

        menuPausa.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        enPausa = false;

        GameManager.instancia.cronometro.ReanudarSimulacion();

        uiManager.OcultarTiempo();

        menuPausa.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}