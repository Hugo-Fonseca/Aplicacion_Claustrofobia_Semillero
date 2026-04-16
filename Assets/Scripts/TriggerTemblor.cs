using UnityEngine;

public class TriggerTemblor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CamaraTemblor temblor = other.GetComponent<CamaraTemblor>();

            if (temblor != null)
            {
                temblor.ActivarTemblor();
            }
        }
    }
}