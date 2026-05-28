using UnityEngine;

public class MenuPrincipalUI : MonoBehaviour
{
    public void SalirJuego()
    {
        Debug.Log("Cerrando aplicación...");

        if (GameManager.instancia != null &&
            GameManager.instancia.guardarDatos != null)
        {
            GameManager.instancia.guardarDatos.Guardar();
        }

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}