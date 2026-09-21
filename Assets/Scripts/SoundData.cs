using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Sound Data")] // Crear un menú para crear SoundData en el editor de Unity
public class SoundData : ScriptableObject // Clase para almacenar datos de sonido
{
    public string id; // Identificador único para el sonido
    public AudioClip clip; // Clip de audio que se reproducirá
    public float volume = 1f; // Volumen del sonido
    public bool loop = false; // Indica si el sonido se reproducirá en bucle
    [Range(0f, 1f)] public float spatialBlend = 0f; // Mezcla espacial del sonido (0 = 2D, 1 = 3D)
    //holi
}
