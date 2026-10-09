using UnityEngine;

public class MetaNivel : MonoBehaviour
{
    public FinNivelUI finNivelUI;

    private bool nivelFinalizado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (nivelFinalizado)
            return;

        if (other.CompareTag("Player"))
        {
            nivelFinalizado = true;

            GameManager.instancia.FinalizarNivel();

            finNivelUI.MostrarPanel();

            Debug.Log("Nivel completado");
        }
    }
}