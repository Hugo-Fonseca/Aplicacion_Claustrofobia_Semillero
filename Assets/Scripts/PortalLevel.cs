using UnityEngine;

public class PortalLevel : MonoBehaviour
{
    public string sceneToLoad;
    public int numeroNivel;
    public string nombreNivel;

    public ConfirmacionNivel confirmacionNivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            confirmacionNivel.MostrarConfirmacion(
                nombreNivel,
                sceneToLoad,
                numeroNivel
            );
        }
    }
}