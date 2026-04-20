using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public CharacterController controller;
    public Transform camara;

    public float velocidadBob = 6f;
    public float cantidadBob = 0.03f;

    private float tiempo = 0f;
    private Vector3 posicionOriginal;

    void Start()
    {
        posicionOriginal = camara.localPosition;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool estaMoviendose = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;

        if (estaMoviendose && controller.isGrounded)
        {
            tiempo += Time.deltaTime * velocidadBob;

            float movimientoY = Mathf.Sin(tiempo) * cantidadBob;
            float movimientoX = Mathf.Cos(tiempo / 2) * cantidadBob * 0.5f;

            camara.localPosition = posicionOriginal + new Vector3(movimientoX, movimientoY, 0);
        }
        else
        {
            tiempo = 0f;
            camara.localPosition = Vector3.Lerp(camara.localPosition, posicionOriginal, Time.deltaTime * 5f);
        }

        Debug.Log(controller.velocity.magnitude);
    }
}
