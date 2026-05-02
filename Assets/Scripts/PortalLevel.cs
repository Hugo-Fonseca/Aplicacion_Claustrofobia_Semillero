using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLevel : MonoBehaviour
{
    public string sceneToLoad;
    public int numeroNivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancia.SeleccionarNivel(numeroNivel);

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}