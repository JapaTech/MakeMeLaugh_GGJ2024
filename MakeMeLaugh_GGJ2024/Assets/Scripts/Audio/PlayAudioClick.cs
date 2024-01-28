using UnityEngine;
using FMODUnity;

public class PlayAudioClick : MonoBehaviour
{
    [field: Header("Audio para tocar")]
    [field: SerializeField] public EventReference AudioParaTocar { get; private set; }

    public void PlayAudio()
    {
        FMODAudioGerenciador.Instance.PlayOneShot(AudioParaTocar);
    }
}
