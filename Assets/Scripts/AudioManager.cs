using UnityEngine;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour, IaudioManager
{
    public static AudioManager Instance { get; private set; } 

    [SerializeField] private List<SoundData> sounds; // Lista de SoundData para almacenar los sonidos

    private Dictionary<string, SoundData> soundDictionary; // Diccionario para acceder a los sonidos por su ID

    private void Awake() // Asegurarse de que solo haya una instancia del AudioManager
    {
        if (Instance != null) // Si ya existe una instancia, destruir el objeto actual
        {
            Destroy(gameObject);
            return;
        }

        Instance = this; // Asignar la instancia actual
        DontDestroyOnLoad(gameObject);

        soundDictionary = new Dictionary<string, SoundData>();

        foreach (var sound in sounds) // Agregar cada SoundData al diccionario
        {
            soundDictionary.Add(sound.id, sound);
        }
    }

    public void Play2D(string soundID) // Método para reproducir un sonido en 2D
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return;

        Play(sound, Vector3.zero, false);
    }

    public void Play3D(string soundID, Vector3 position) // Método para reproducir un sonido en 3D
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return;

        Play(sound, position, true);
    }

    private void Play(SoundData sound, Vector3 position, bool is3D) // Método para reproducir un sonido
    {
        GameObject go = new GameObject("Audio_" + sound.id); // Crear un GameObject temporal para reproducir el sonido
        go.transform.position = position;

        AudioSource source = go.AddComponent<AudioSource>(); // Agregar un componente AudioSource al GameObject
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.loop = sound.loop;
        source.spatialBlend = is3D ? 1f : 0f;

        source.Play(); // Reproducir el sonido

        if (!sound.loop)
            Destroy(go, sound.clip.length);
    }
}
public interface IaudioManager // Interfaz para el AudioManager
{
    void Play2D(string id);
    void Play3D(string id, Vector3 location);

}