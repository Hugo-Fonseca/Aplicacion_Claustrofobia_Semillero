using UnityEngine;
using System.Collections;

public class FadeInAudio : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource que se desea controlar
    public float volumenInicial = 0.1f; // Volumen inicial del audio
    public float volumenFinal = 1f; // Volumen final del audio
    public float duracion = 90f; // Duración del fade-in en segundos

    void Start()
    {
        audioSource.volume = volumenInicial; // Establecer el volumen inicial del audio
        StartCoroutine(SubirVolumen());
    }

    IEnumerator SubirVolumen()
    {
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;

            audioSource.volume = Mathf.Lerp(
                volumenInicial,
                volumenFinal,
                tiempo / duracion
            );

            yield return null;
        }

        audioSource.volume = volumenFinal;
    }
}