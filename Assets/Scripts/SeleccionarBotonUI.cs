using UnityEngine;
using UnityEngine.EventSystems;

public class SeleccionarBotonUI : MonoBehaviour
{
    public GameObject botonInicial;

    void OnEnable()
    {
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(botonInicial);
        }
    }
}