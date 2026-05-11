using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ConfirmacionNivel : MonoBehaviour
{
    public GameObject panelConfirmacion;
    public TextMeshProUGUI textoTitulo;

    private string escenaDestino;
    private int numeroNivel;

    public void MostrarConfirmacion(string nombreNivel, string escena, int nivel)
    {
        panelConfirmacion.SetActive(true);

        textoTitulo.text = nombreNivel;

        escenaDestino = escena;
        numeroNivel = nivel;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void IrAlNivel()
    {
        GameManager.instancia.SeleccionarNivel(numeroNivel);

        SceneManager.LoadScene(escenaDestino);
    }

    public void Cancelar()
    {
        panelConfirmacion.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
