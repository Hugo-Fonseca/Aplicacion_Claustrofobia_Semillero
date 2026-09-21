using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarSonido : MonoBehaviour
{
    public GameObject puntoEntrada;
    public GameObject puntoSalida;

    public string sonidoEntrada;
    public string sonidoSalida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.Play3D(sonidoEntrada, puntoEntrada.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.Play3D(sonidoSalida, puntoSalida.transform.position);
        }
    }
}