using UnityEngine;

public class MetaNivel : MonoBehaviour
{
    public FinNivelUI finNivelUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancia.cronometro.FinalizarNivel();

            GameManager.instancia.GuardarTiempoNivel();

            finNivelUI.MostrarPanel();

            Debug.Log("Nivel completado");
        }
    }
}