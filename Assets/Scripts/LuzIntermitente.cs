using UnityEngine;
using System.Collections;

public class LuzIntermitente : MonoBehaviour
{
    public Light luz;

    [Header("Tiempo encendida")]
    public float minimoEncendida = 1f;
    public float maximoEncendida = 5f;

    [Header("Tiempo apagada")]
    public float minimoApagada = 1f;
    public float maximoApagada = 4f;

    void Start()
    {
        if (luz == null)
        {
            luz = GetComponent<Light>();
        }

        StartCoroutine(Intermitencia());
    }

    IEnumerator Intermitencia()
    {
        while (true)
        {
            // Encender
            luz.enabled = true;

            float tiempoEncendida = Random.Range(
                minimoEncendida,
                maximoEncendida
            );

            yield return new WaitForSeconds(tiempoEncendida);

            // Apagar
            luz.enabled = false;

            float tiempoApagada = Random.Range(
                minimoApagada,
                maximoApagada
            );

            yield return new WaitForSeconds(tiempoApagada);
        }
    }
}