using UnityEngine;

public class CamaraTemblor : MonoBehaviour
{
    public Transform camara;

    public float duracion = 2f;
    public float intensidad = 0.1f;

    private float tiempoRestante = 0f;
    private Vector3 posicionOriginal;

    void Start()
    {
        posicionOriginal = camara.localPosition;
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            Vector3 offset = Random.insideUnitSphere * intensidad;
            camara.localPosition = posicionOriginal + offset;

            tiempoRestante -= Time.deltaTime;
        }
        else
        {
            camara.localPosition = posicionOriginal;
        }
    }

    public void ActivarTemblor()
    {
        tiempoRestante = duracion;
    }
}