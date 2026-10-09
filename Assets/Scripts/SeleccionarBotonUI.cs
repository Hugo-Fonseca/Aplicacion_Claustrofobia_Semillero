using UnityEngine;
using UnityEngine.EventSystems;

public class SeleccionarBotonUI : MonoBehaviour
{
    public GameObject botonInicial; // Referencia al botón que deseas seleccionar al inicio

    void OnEnable()
    {
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(botonInicial); // Establecer el botón inicial como seleccionado
        }
    }
}