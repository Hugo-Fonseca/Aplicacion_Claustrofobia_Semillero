using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeSalir : MonoBehaviour
{
    public GameObject menuPausa;
    public UIManager uiManager;

    private bool enPausa = false;

    void Update()
    {
        // ESC del teclado para PC
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            CambiarPausa();
        }
    }

    // Esta función será utilizada por ESC y por START
    public void CambiarPausa()
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

    // Botón START del control
    public void OnStart(InputValue value)
    {
        if (value.isPressed)
        {
            CambiarPausa();
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

    public void BotonSalir()
    {
        Debug.Log("BOTON SALIR FUNCIONA");

        GameManager.instancia.SalirAplicacion();
    }
}