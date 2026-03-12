using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaNivel : MonoBehaviour
{
    public FinNivelUI finNivelUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancia.cronometro.FinalizarNivel();

            int escena = SceneManager.GetActiveScene().buildIndex;

            if (escena == 1)
            {
                GameManager.instancia.escNivel1 = GameManager.instancia.vecesEscNivel;
                GameManager.instancia.tiempoNivel1 = GameManager.instancia.cronometro.tiempoNivel;
            }

            if (escena == 2)
            {
                GameManager.instancia.escNivel2 = GameManager.instancia.vecesEscNivel;
                GameManager.instancia.tiempoNivel2 = GameManager.instancia.cronometro.tiempoNivel;
            }

            if (escena == 3)
            {
                GameManager.instancia.escNivel3 = GameManager.instancia.vecesEscNivel;
                GameManager.instancia.tiempoNivel3 = GameManager.instancia.cronometro.tiempoNivel;
            }

            if (escena == 4)
            {
                GameManager.instancia.escNivel4 = GameManager.instancia.vecesEscNivel;
                GameManager.instancia.tiempoNivel4 = GameManager.instancia.cronometro.tiempoNivel;
            }

            finNivelUI.MostrarPanel();

            Debug.Log("Nivel completado");
        }
    }
}