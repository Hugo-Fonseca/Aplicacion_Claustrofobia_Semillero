using UnityEngine;

public class EscapeSalir : MonoBehaviour
{
    public GameObject menuPausa;

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

        FindObjectOfType<UIManager>().MostrarTiempo();

        menuPausa.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        enPausa = false;

        GameManager.instancia.cronometro.ReanudarSimulacion();

        FindObjectOfType<UIManager>().OcultarTiempo();

        menuPausa.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}