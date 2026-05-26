using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "VariousSFX", menuName = "Scriptable Objects/VariousSFX")]
public class VariousSFX : ScriptableObject
{
    public AudioClip[] SoundVarients;
    public void Play(AudioSource source){
        source.PlayOneShot(SoundVarients[Random.Range(0,SoundVarients.Length)]);
    }
}
