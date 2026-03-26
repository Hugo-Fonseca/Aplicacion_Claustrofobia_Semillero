using UnityEngine;

public class ReplaceObjects : MonoBehaviour
{
    public GameObject prefabReemplazo;

    void Start()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Replace");

        foreach (GameObject obj in objetos)
        {
            GameObject nuevo = Instantiate(prefabReemplazo, obj.transform.position, obj.transform.rotation);
            nuevo.transform.localScale = obj.transform.localScale;

            Destroy(obj);
        }
    }
}